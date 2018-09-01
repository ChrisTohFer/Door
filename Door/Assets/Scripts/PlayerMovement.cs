using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;
    public float MaxSpeed;

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        rb.velocity = MaxSpeed * new Vector3(x, 0f, z);

        if (rb.velocity.magnitude > 0f)
        {
            transform.LookAt(transform.position + rb.velocity);
            transform.rotation = transform.rotation * Quaternion.Euler(-90f, 90f, 0f);
        }
    }
}
