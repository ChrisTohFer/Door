using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

    public Animator DoorAnimation;

    private void FixedUpdate()
    {
        if(GameControl.Repeated)
        {
            if(DoorAnimation.GetCurrentAnimatorStateInfo(0).IsName("Intro"))
            {
                DoorAnimation.SetFloat("IntroSpeed", 1000f);
            }
        }
        if(GameControl.IntroPlaying && Input.GetKeyDown(KeyCode.Escape))
        {
            DoorAnimation.SetFloat("IntroSpeed", 1000f);
            AudioManager.manager.StopIntroSoundtrack();
            AudioManager.manager.StartMainSoundtrack();
            GameControl.IntroPlaying = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && GameControl.KeysHeld)
        {
            GameControl.GameWon = true;
            DoorAnimation.SetBool("DoorOpened", true);
            GameControl.GC.PlayerObject.transform.position = new Vector3(1.0f, -0.3f, -0.5f) + transform.position;
            GameControl.GC.PlayerObject.transform.rotation = Quaternion.Euler(0f, -45f, 0f);
        }
    }

}
