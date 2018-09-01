using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour {

    [EventRef]
    public string IntroSoundtrackRef;

    [EventRef]
    public string StealthSoundtrackRef;

    private EventInstance IntroSoundtrack;
    private EventInstance StealthSoundtrack;

    public static AudioManager manager;

    // Use this for initialization
    void Start() {
        if(manager == null)
        {
            manager = this;
            DontDestroyOnLoad(gameObject);

            IntroSoundtrack = CreateFMODEventInstance(IntroSoundtrackRef);
            StealthSoundtrack = CreateFMODEventInstance(StealthSoundtrackRef);

            StealthSoundtrack.start();

        }
        else
        {
            Destroy(gameObject);
        }

        
    }

    private EventInstance CreateFMODEventInstance(string eventRef)
    {
        return RuntimeManager.CreateInstance(eventRef);
    }
}
