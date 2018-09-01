using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameControl : MonoBehaviour {

    public GameObject PlayerObject;
    public static GameControl GC;
    public static bool PlayerCaught = false;

    //public UnityEvent Death;

    private void Awake()
    {
        PlayerCaught = false;
        GC = this;
    }
    public void OnDeath()
    {
        AudioManager.manager.StopFootsteps();
        AudioManager.manager.PlayDetectedSound();
    }
    private void Start()
    {
        AudioManager.manager.StartMainSoundtrack();
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            ReloadScene();
    }
    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
