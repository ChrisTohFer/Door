using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameControl : MonoBehaviour {

    public GameObject PlayerObject;
    public static GameControl GC;
    public static bool PlayerCaught = false;
    public static bool KeysHeld = false;
    public static bool GameWon = false;
    public static bool IntroPlaying = true;
    public static bool Repeated = false;
    private int Keys = 0;

    //public UnityEvent Death;

    public void PickupKey()
    {
        Keys++;
        if(Keys == 3)
        {
            KeysHeld = true;
        }
        Debug.Log(Keys);
    }
    private void Awake()
    {
        PlayerCaught = false;
        KeysHeld = false;
        GameWon = false;
        GC = this;
        Keys = 0;

    }
    public void OnDeath()
    {
        AudioManager.manager.StopFootsteps();
        AudioManager.manager.PlayDetectedSound();
    }
    private void Start()
    {
        if (!Repeated)
        {
            AudioManager.manager.StartIntroSoundtrack();
            AudioManager.manager.Invoke("StartMainSoundtrack", 27f);
        }
        else
        {
            AudioManager.manager.StartMainSoundtrack();
        }
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !IntroPlaying)
            ReloadScene();
    }
    private void ReloadScene()
    {
        Repeated = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
