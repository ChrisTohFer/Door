using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

    public GameObject PlayerObject;
    public static GameControl GC;
    public static bool PlayerCaught = false;


    private void Awake()
    {
        PlayerCaught = false;
        GC = this;
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
