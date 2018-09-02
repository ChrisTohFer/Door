using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class moves the player and makes them face their movement direction

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;
    public float MaxSpeed;

    public BoxControl BC;
    public UnityEngine.UI.Image RedKey;
    public UnityEngine.UI.Image BlueKey;
    public UnityEngine.UI.Image GreenKey;

    public UnityEngine.UI.Text GuardSpinCounter;
    private int _spunOut = 0;
    
    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (GameControl.PlayerCaught || GameControl.IntroPlaying || GameControl.GameWon)
        {
            return;
        }
        rb.velocity = MaxSpeed * new Vector3(x, 0f, z);

        if(rb.velocity.magnitude > MaxSpeed * 0.1f)
        {
            AudioManager.manager.StartFootsteps();
        }
        else
        {
            AudioManager.manager.StopFootsteps();
        }

        if (rb.velocity.magnitude > MaxSpeed * 0.05f)
        {
            transform.LookAt(transform.position + rb.velocity);
            //transform.rotation = transform.rotation * Quaternion.Euler(-90f, 90f, 0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Guard")
        {
            _spunOut++;
            GuardSpinCounter.text = "Guards spun out: " + _spunOut;
            GuardSpinCounter.gameObject.SetActive(true);

            AudioManager.manager.PlayGuardCollideSound();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "BoxPickup")
        {
            BC.RefreshTime();
            AudioManager.manager.PlayCardboardBoxSound();
        }
        else if(other.tag == "RedKey")
        {
            AudioManager.manager.PlayKeyCollectSound();
            RedKey.gameObject.SetActive(true);
            GameControl.GC.PickupKey();
        }
        else if (other.tag == "BlueKey")
        {
            AudioManager.manager.PlayKeyCollectSound();
            BlueKey.gameObject.SetActive(true);
            GameControl.GC.PickupKey();
        }
        else if (other.tag == "GreenKey")
        {
            AudioManager.manager.PlayKeyCollectSound();
            GreenKey.gameObject.SetActive(true);
            GameControl.GC.PickupKey();
        }
    }

}
