using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

    public static bool PlayerCaught = false;

    private void Awake()
    {
        PlayerCaught = false;
    }
}
