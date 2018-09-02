using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGuard : MonoBehaviour {

    public Rigidbody rb;
    public Transform WayPoint1, WayPoint2;
    public bool Returning = false;
    public bool Clockwise = true;
    public bool KeepCounting = false;
    public float WaitTime = 4f;
    public float Speed = 5f;
    public float TurnSpeed = 1f;

    public bool _waiting = false;
    private bool _rotating = true;

    private bool _spunOut = false;

    public float _timer;

    private void OnEnable()
    {
        if(_timer == 0)
        {
            _timer = WaitTime;
        }
    }

    private void FixedUpdate()
    {
        if(!_spunOut)
        {
            if(_waiting)
            {
                Waiting();
            }
            else if(_rotating)
            {
                FaceDestination();
            }
            else
            {
                MoveToDestination();
            }

            if(KeepCounting && !_waiting)
            {
                _timer -= Time.fixedDeltaTime;
            }
        }
    }
    private void Waiting()
    {
        if(_timer > 0f)
        {
            _timer -= Time.fixedDeltaTime;
        }
        else
        {
            _waiting = false;
            _rotating = true;
            _timer = WaitTime;
        }
    }
    private void FaceDestination()
    {
        float Angle;
        Vector3 Displacement;
        Transform t;
        if(Returning)
        {
            t = WayPoint1;
        }
        else
        {
            t = WayPoint2;
        }

        Displacement = t.position - transform.position;
        Angle = Mathf.PI / 180f * Vector3.Angle(transform.forward, Displacement);

        if (Clockwise)
        {
            if (Angle < TurnSpeed * Time.fixedDeltaTime)
            {
                transform.LookAt(t);
                rb.angularVelocity = Vector3.zero;
                _rotating = false;
            }
            else
            {
                rb.angularVelocity = new Vector3(0f, TurnSpeed, 0f);
            }
        }
        else
        {
            if (Angle < TurnSpeed * Time.fixedDeltaTime)
            {
                transform.LookAt(t);
                rb.angularVelocity = Vector3.zero;
                _rotating = false;
            }
            else
            {
                rb.angularVelocity = new Vector3(0f, -TurnSpeed, 0f);
            }
        }
    }
    private void MoveToDestination()
    {
        Vector3 displacement;
        Vector3 velocity;

        if (Returning)
        {
            displacement = WayPoint1.position - transform.position;
        }
        else
        {
            displacement = WayPoint2.position - transform.position;
        }

        if(displacement.magnitude < Speed * Time.fixedDeltaTime)
        {
            transform.position = transform.position + displacement;
            velocity = Vector3.zero;
            Returning = !Returning;
            _waiting = true;
        }
        else
        {
            velocity = Speed * (displacement).normalized;
        }

        rb.velocity = velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _spunOut = true;
        }
    }

}
