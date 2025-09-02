using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using FMODUnity;
using TMPro;

public class GameManager : MonoBehaviour
{
    public etee.eteeAPI api;

    public static GameManager instance;

    public bool startPlaying;
    public BeatScroller beatScroller;
    [SerializeField] private EventReference LevelMusic;
    
    public int currentScore;
    public int scorePerNote = 100;

    public TMP_Text scoreText;
    public TMP_Text multiText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreText.text = "Score: 0";
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

        currentScore += scorePerNote;
        scoreText.text = "Score: " + currentScore;
    }

    public void BeatMissed()
    {
        UnityEngine.Debug.Log("Missed Beat");
    }
}
