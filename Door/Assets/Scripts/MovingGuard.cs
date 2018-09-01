using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGuard : MonoBehaviour {

    public Rigidbody rb;
    public Transform WayPoint1, WayPoint2;
    public int Destination = 0;
    public float WaitTime = 4f;
    public float Speed = 5f;
    public float TurnSpeed = 90f;

    private bool _waiting = false;
    private bool _rotating = true;

    private void FixedUpdate()
    {
        
    }
    private void MoveToDestination()
    {
        if(Destination == 0)
        {
            Vector3 displacement = WayPoint1.position - transform.position;
            Vector3 velocity;

            if(displacement.magnitude < Speed)
            {
                velocity = displacement;
            }
            else
            {
                velocity = Speed * (displacement).normalized;
            }

            rb.velocity = velocity;
        }
    }


}
