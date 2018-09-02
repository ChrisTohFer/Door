using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxControl : MonoBehaviour {

    public Animator Controller;

    public float BoxTime = 10f;
    private float _timer;
    public Text text;

    private int _nextCountdownSoundInterval = 3;

    private void Awake()
    {
        _timer = BoxTime;
        text.text = "Box Time: " + Mathf.RoundToInt(_timer);
    }

    private void FixedUpdate()
    {
        AnimatorTransitionInfo info = Controller.GetAnimatorTransitionInfo(0);
        
        if(Input.GetKey(KeyCode.Space) && _timer > 0f && !GameControl.PlayerCaught)
        {
            Controller.SetBool("SpaceDown", true);
            _timer -= Time.fixedDeltaTime;

            var timerRoundedToInt = Mathf.RoundToInt(_timer);
            text.text = "Box Time: " + timerRoundedToInt;

            if (timerRoundedToInt <= _nextCountdownSoundInterval && timerRoundedToInt >= 0)
            {
                AudioManager.manager.PlayCountdownSound(timerRoundedToInt);
                _nextCountdownSoundInterval -= 1;
            }
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
        _nextCountdownSoundInterval = 3;
    }
}
