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

    // Use this for initialization
    void Start() {
        IntroSoundtrack = CreateFMODEventInstance(IntroSoundtrackRef);
        StealthSoundtrack = CreateFMODEventInstance(StealthSoundtrackRef);

        StealthSoundtrack.start();
    }

    private EventInstance CreateFMODEventInstance(string eventRef)
    {
        return RuntimeManager.CreateInstance(eventRef);
    }
}
