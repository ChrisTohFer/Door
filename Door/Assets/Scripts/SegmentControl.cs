using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentControl : MonoBehaviour {

    public Transform CamHolder;
    public GameObject PlayerObject;
    public float XPeriod = 20f;
    public float YPeriod = 10f;

    private void LateUpdate()
    {
        if(!GameControl.IntroPlaying && !GameControl.GameWon)
        {
            
            float x = Mathf.Round(PlayerObject.transform.position.x / XPeriod) * XPeriod;
            float y = Mathf.Round(PlayerObject.transform.position.z / YPeriod) * YPeriod;

            CamHolder.position = new Vector3(x, 0f, y);
            
        }
        
    }
}
