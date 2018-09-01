using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxControl : MonoBehaviour {

    public Animator Controller;

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            Controller.SetBool("SpaceDown", true);
        }
        else
        {
            Controller.SetBool("SpaceDown", false);
        }
    }
}
