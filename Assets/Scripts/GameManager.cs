using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using System.Diagnostics;

public class GameManager : MonoBehaviour
{
    public etee.eteeAPI api;

    public static GameManager instance;

    public bool startPlaying;
    public BeatScroller beatScroller;
    [SerializeField] private EventReference LevelMusic;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (api.GetIsSqueezeGesture(0) == true && api.GetIsSqueezeGesture(1) == true || Input.GetKeyDown(KeyCode.Space))
            {
                startPlaying = true;
                beatScroller.hasStarted = true;

                // Play the music
                AudioManager.instance.InitializeMusic(LevelMusic, this.transform.position);
            }
        }
    }

    public void BeatHit()
    {
        UnityEngine.Debug.Log("Hit On Time");
    }

    public void BeatMissed()
    {
        UnityEngine.Debug.Log("Missed Beat");
    }
}
