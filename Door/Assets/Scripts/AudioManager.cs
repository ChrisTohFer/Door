using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour {

    // Soundtrack


    [EventRef] public string IntroSoundtrackRef;
    [EventRef] public string StealthSoundtrackRef;

    // SFX


    [EventRef] public string Footsteps;
    [EventRef] public string KeyCollect;
    [EventRef] public string CardboardBox;
    [EventRef] public string DoorUnlock;
    [EventRef] public string Detected;
    [EventRef] public string GameOver;


    private EventInstance introSoundtrack;
    private EventInstance stealthSoundtrack;
    private EventInstance footsteps;

    public static AudioManager manager;

    // Use this for initialization
    void Start() {
        if(manager == null)
        {
            manager = this;
            DontDestroyOnLoad(gameObject);

            // Create soundtrack instances
            introSoundtrack = CreateFMODEventInstance(IntroSoundtrackRef);
            stealthSoundtrack = CreateFMODEventInstance(StealthSoundtrackRef);

            // Need instance for this as footsteps is a looping event
            footsteps = CreateFMODEventInstance(Footsteps);

            PlayDetectedSound();

        }
        else
        {
            Destroy(gameObject);
        }        
    }

    /// <summary>
    /// The intro soundtrack, to be played before gameplay begins
    /// </summary>
    public void StartIntroSoundtrack()
    {
        introSoundtrack.start();
    }

    public void StopIntroSoundtrack()
    {
        introSoundtrack.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    /// <summary>
    /// The gameplay background music
    /// </summary>
    public void StartMainSoundtrack()
    {
        stealthSoundtrack.start();
    }

    public void StopMainSoundtrack()
    {
        stealthSoundtrack.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    /// <summary>
    /// Footsteps have a start and stop method as the sound effect loops
    /// </summary>
    public void StartFootsteps()
    {
        footsteps.start();
    }

    public void StopFootsteps()
    {
        footsteps.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    /// <summary>
    /// On key collection
    /// </summary>
    public void PlayKeyCollectSound()
    {
        PlayOneShot(KeyCollect);
    }

    /// <summary>
    /// Upon putting on / removing the cardboard box
    /// </summary>
    public void PlayCardboardBoxSound()
    {
        PlayOneShot(CardboardBox);
    }

    /// <summary>
    /// When a key is used on the door.
    /// NOT the door open sound.
    /// </summary>
    public void PlayDoorUnlockSound()
    {
        PlayOneShot(DoorUnlock);
    }

    /// <summary>
    /// On player being detected by the enemy
    /// </summary>
    public void PlayDetectedSound()
    {
        PlayOneShot(Detected);
    }

    /// <summary>
    /// Game over sound, after having been spotted.
    /// </summary>
    public void PlayGameOverSound()
    {
        PlayOneShot(GameOver);
    }

    private void PlayOneShot(string eventRef)
    {
        RuntimeManager.PlayOneShot(eventRef);
    }

    private EventInstance CreateFMODEventInstance(string eventRef)
    {
        return RuntimeManager.CreateInstance(eventRef);
    }

    private void OnDestroy()
    {
        // Stop all active sounds
        introSoundtrack.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        stealthSoundtrack.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        footsteps.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);

        introSoundtrack.release();
        stealthSoundtrack.release();
        footsteps.release();
    }
}
