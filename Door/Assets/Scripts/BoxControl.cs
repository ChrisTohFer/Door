using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxControl : MonoBehaviour {

    public Animator Controller;

    public float BoxTime = 10f;
    private float _timer;

    private void Awake()
    {
        _timer = BoxTime;
    }

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Space) && _timer > 0f)
        {
            Controller.SetBool("SpaceDown", true);
            _timer -= Time.fixedDeltaTime;
        }
        else
        {
            Controller.SetBool("SpaceDown", false);
        }
    }

    public void RefreshTime()
    {
        _timer = BoxTime;
    }
}
