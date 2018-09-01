using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class moves the player and makes them face their movement direction

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;
    public float MaxSpeed;
    public BoxControl BC;

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
    }

}
