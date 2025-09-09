using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using FMODUnity;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public etee.eteeAPI api;

    public static GameManager instance;

    public bool startPlaying;
    public BeatScroller beatScroller;
    [SerializeField] private EventReference LevelMusic;
    //public int currentLevel = 1;
    
    public int currentScore;
    public int scorePerBeat = 100;
    // --Different types of hits--
    //public int scorePerGoodBeat = 125;
    //public int scorePerPerfectBeat = 150;

    public TMP_Text scoreText;
    public TMP_Text multiText;

    private float totalBeats;
    private float normalHits;
    // --Different types of hits--
    //private float goodHits;
    //private float perfectHits;
    private float missedHits;

    public GameObject resultsScreen;
    public GameObject startScreen;
    public TMP_Text percentHitText, normalsText, missesText, rankText, finalScoreText;

    // Start is called before the first frame update
    void Start()
    {
        api.RestartStreaming();

        instance = this;
        scoreText.text = "Score: 0";
        currentMultiplier = 1;

        // Finds all objects with the script 'BeatObject'.
        totalBeats = FindObjectsOfType<BeatObject>().Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (api.GetIsSqueezeGesture(0) == true && api.GetIsSqueezeGesture(1) == true || Input.GetKeyDown(KeyCode.Space))
            {
                startPlaying = true;
                startScreen.SetActive(false);
                beatScroller.hasStarted = true;

                // Play the music
                AudioManager.instance.InitializeMusic(LevelMusic, this.transform.position);
            }
        }
        else
        {
            if (AudioManager.instance.IsMusicStopped() && !resultsScreen.activeInHierarchy)
            {
                UnityEngine.Debug.Log("Music has finished!");
                resultsScreen.SetActive(true);

                normalsText.text = normalHits.ToString();
                missesText.text = missedHits.ToString();

                float totalHit = normalHits;
                float percentHit = (totalHit / totalBeats) * 100f;
                percentHitText.text = percentHit.ToString("F1") + "%";

                string rankValue = "F";
                if (percentHit > 40)
                {
                    rankValue = "D";

                    if (percentHit > 55)
                    {
                        rankValue = "C";

                        if (percentHit > 70)
                        {
                            rankValue = "B";

                            if (percentHit > 85)
                            {
                                rankValue = "A";

                                if (percentHit > 95)
                                {
                                    rankValue = "S";
                                }
                            }
                        }
                    }
                }

                rankText.text = rankValue;

                finalScoreText.text = currentScore.ToString();
            }

            //levelContinue();
        }
    }

    public void BeatHit()
    {
        UnityEngine.Debug.Log("Hit On Time");

        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;

            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        multiText.text = "Multiplier: x" + currentMultiplier;

        currentScore += scorePerBeat * currentMultiplier;
        scoreText.text = "Score: " + currentScore;

        normalHits++;   // - can remove if different types of hits added -
    }

    // --Different types of hits--
    //public void NormalHit()
    //{
    //    currentScore += scorePerBeat * currentMultiplier;
    //    BeatHit();
    //}

    //public void GoodHit()
    //{
    //    currentScore += scorePerGoodBeat * currentMultiplier;
    //    BeatHit();
    //}

    //public void PerfectHit()
    //{
    //    currentScore += scorePerPerfectBeat * currentMultiplier;
    //    BeatHit();
    //}

    public void BeatMissed()
    {
        UnityEngine.Debug.Log("Missed Beat");

        currentMultiplier = 1;
        multiplierTracker = 0;

        multiText.text = "Multiplier: x" + currentMultiplier;

        missedHits++;
    }

    //public void levelContinue()
    //{
    //    if (AudioManager.instance.IsMusicStopped() && resultsScreen.activeInHierarchy)
    //    {
    //        if (api.GetIsSqueezeGesture(0) == true && api.GetIsSqueezeGesture(1) == true || Input.GetKeyDown(KeyCode.Space))
    //        {
    //            SceneManager.LoadScene("Level_" + (currentLevel + 1).ToString());
    //        }
    //    }
    //}
}
