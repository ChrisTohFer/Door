using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleGuard : MonoBehaviour {

    public float Speed;
    public bool Clockwise;
    public Rigidbody rb;
    public Transform trans;

    private bool _spunOut = false;
    private float _radius, _circumferance;
    private float _parameter;

    private void OnEnable()
    {
        _radius = (trans.position - transform.position).magnitude;
        _circumferance = 2f * Mathf.PI * _radius;
        float angle = Vector3.SignedAngle(Vector3.forward, trans.position - transform.position, Vector3.up);
        _parameter = Mathf.Repeat(angle * Mathf.PI / 180f, Mathf.PI * 2f);
    }

    private void FixedUpdate()
    {
        if(!_spunOut)
        {
            float way = Clockwise ? 1f : -1f;

            _parameter += way * 2f * Mathf.PI * Speed * Time.deltaTime / _circumferance;
            float x = transform.position.x + _radius * Mathf.Sin(_parameter);
            float z = transform.position.z + _radius * Mathf.Cos(_parameter);
            Vector3 direction = new Vector3(x, trans.position.y, z) - trans.position;
            rb.velocity = direction.normalized * Speed;

            trans.LookAt(direction + trans.position);
        }
    }

    public void SpinOut()
    {
        _spunOut = true;
    }
}
