using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardDetection : MonoBehaviour {

    public GameObject Exclamation;
    public float SearchLength = 5f;
    public float SearchAngle = 90f;

    private void SearchPlayer()
    {
        if(GameControl.PlayerCaught)
        {
            return;
        }

        Vector3 gap = GameControl.GC.PlayerObject.transform.position - transform.position;
        gap = new Vector3(gap.x, 0f, gap.z);
        
        if (gap.magnitude < SearchLength && Mathf.Abs(Vector3.SignedAngle(gap, transform.forward, Vector3.up)) < SearchAngle * 0.5f)
        {
            Ray ray = new Ray(transform.position, gap);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, SearchLength);

            if(hit.collider.tag == "Player")
            {
                PlayerCaught();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Guard")
        {
            // AudioManager.manager.PlayGuardCollideSound(collision.transform.position);
        }
    }

    private void FixedUpdate()
    {
        SearchPlayer();
    }

    private void PlayerCaught()
    {
        Debug.Log("Caught");
        GameControl.PlayerCaught = true;
        GameControl.GC.OnDeath();
        Exclamation.SetActive(true);
    }
}
