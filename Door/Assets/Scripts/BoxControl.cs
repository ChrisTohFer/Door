using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxControl : MonoBehaviour {

    public Animator Controller;

    public float BoxTime = 10f;
    private float _timer;
    public Text text;

    private void Awake()
    {
        _timer = BoxTime;
        text.text = "Box Time: " + Mathf.RoundToInt(_timer);
    }

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Space) && _timer > 0f)
        {
            Controller.SetBool("SpaceDown", true);
            _timer -= Time.fixedDeltaTime;
            text.text = "Box Time: " + Mathf.RoundToInt(_timer);
        }
        else
        {
            Controller.SetBool("SpaceDown", false);
        }
    }

    public void RefreshTime()
    {
        _timer = BoxTime;
        text.text = "Box Time: " + Mathf.RoundToInt(_timer);
    }
}
