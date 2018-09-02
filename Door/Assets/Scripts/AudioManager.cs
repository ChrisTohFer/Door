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
    [EventRef] public string Countdown;
    [EventRef] public string SecretDoorOpening;


    private EventInstance introSoundtrack;
    private EventInstance stealthSoundtrack;
    private EventInstance footsteps;

    public static AudioManager manager;

    // Use this for initialization
    void Awake() {
        if(manager == null)
        {
            manager = this;
            DontDestroyOnLoad(gameObject);

            // Create soundtrack instances
            introSoundtrack = CreateFMODEventInstance(IntroSoundtrackRef);
            stealthSoundtrack = CreateFMODEventInstance(StealthSoundtrackRef);

            // Need instance for this as footsteps is a looping event
            footsteps = CreateFMODEventInstance(Footsteps);
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

    bool MainSoundtrackPlaying = false;
    /// <summary>
    /// The gameplay background music
    /// </summary>
    public void StartMainSoundtrack()
    {
        if (!MainSoundtrackPlaying)
        {
            stealthSoundtrack.start();
            MainSoundtrackPlaying = true;
        }
    }

    public void StopMainSoundtrack()
    {
        if (MainSoundtrackPlaying)
        {
            stealthSoundtrack.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            MainSoundtrackPlaying = false;
        }
    }

    bool FootstepsPlaying = false;
    /// <summary>
    /// Footsteps have a start and stop method as the sound effect loops
    /// </summary>
    public void StartFootsteps()
    {
        if (!FootstepsPlaying)
        {
            footsteps.start();
            FootstepsPlaying = true;
        }
    }

    public void StopFootsteps()
    {
        if (FootstepsPlaying)
        {
            footsteps.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            FootstepsPlaying = false;
        }
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

    /// <summary>
    /// Countdown sound, counts down from 3
    /// </summary>
    public void PlayCountdownSound(int countdownTimerValue)
    {
        if (countdownTimerValue <= 3 && countdownTimerValue >= 0)
        {
            var instance = RuntimeManager.CreateInstance(Countdown);
            instance.setParameterValue("CountdownNumber", countdownTimerValue);
            instance.start();
            instance.release();
        }
    }

    public void PlaySecretDoorOpeningSound()
    {
        PlayOneShot(SecretDoorOpening);
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
