using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardDetection : MonoBehaviour {

    public GameObject Exclamation;
    public BoxCollider Col;
    public float SearchLength = 5f;

    private void OnEnable()
    {
        Col.size = new Vector3(SearchLength, 5f, SearchLength);
        Col.transform.localPosition = new Vector3(0f, 0.1f, Mathf.Sqrt(0.5f * SearchLength * SearchLength));
    }

    private void PlayerCaught()
    {
        Debug.Log("Caught");
        GameControl.PlayerCaught = true;
        Exclamation.SetActive(true);
    }
    private void OnPlayerDetected(Collider other)
    {
        if ((other.transform.position - transform.parent.position).magnitude < SearchLength)
        {
            PlayerCaught();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !GameControl.PlayerCaught)
        {
            OnPlayerDetected(other);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && !GameControl.PlayerCaught)
        {
            OnPlayerDetected(other);
        }
    }
}
