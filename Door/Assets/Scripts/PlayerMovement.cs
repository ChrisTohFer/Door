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
    
    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (GameControl.PlayerCaught)
        {
            return;
        }
        rb.velocity = MaxSpeed * new Vector3(x, 0f, z);

        if (rb.velocity.magnitude > MaxSpeed * 0.05f)
        {
            transform.LookAt(transform.position + rb.velocity);
            //transform.rotation = transform.rotation * Quaternion.Euler(-90f, 90f, 0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "BoxPickup")
        {
            BC.RefreshTime();
        }
        else if(other.tag == "RedKey")
        {
            RedKey.gameObject.SetActive(true);
        }
        else if (other.tag == "BlueKey")
        {
            BlueKey.gameObject.SetActive(true);
        }
        else if (other.tag == "GreenKey")
        {
            GreenKey.gameObject.SetActive(true);
        }
    }

}
