using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using FMODUnity;
using System.Collections.Specialized;
using System;

public class AudioManager : MonoBehaviour
{
    public FMOD.Studio.EventInstance musicEventInstance;

    public static AudioManager instance { get; private set; }

    private void Awake()
    {
        if(instance != null)
        {
            UnityEngine.Debug.LogError("Found more than one Audio Manager in the scene.");
        }

        instance = this;
    }

    public void InitializeMusic(EventReference musicEvent, Vector3 worldPos)
    {
        if (musicEventInstance.isValid())
        {
            musicEventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            musicEventInstance.release();
        }

        musicEventInstance = RuntimeManager.CreateInstance(musicEvent);
        RuntimeManager.AttachInstanceToGameObject(musicEventInstance, transform, GetComponent<Rigidbody>());

        musicEventInstance.start();
    }

    public void StopMusic()
    {
        if (musicEventInstance.isValid())
        {
            musicEventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            musicEventInstance.release();
        }
    }

    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }
}
