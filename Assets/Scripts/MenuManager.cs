using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    // References to necessary etee components.
    public etee.eteeAPI api;

    public MenuRotation menuRotation;

    private bool hapticsEnabled = true;
    public GameObject enabledText;
    public GameObject disabledText;

    void Start()
    {
        api = GameObject.Find("/ContinuousObject/eteeAPI/API").GetComponent<etee.eteeAPI>();

        if (hapticsEnabled)
        {
            enabledText.SetActive(true);
            disabledText.SetActive(false);
            api.EnableHaptics();
        }
        else
        {
            enabledText.SetActive(false);
            disabledText.SetActive(true);
            api.DisableHaptics();
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            back();
        }
    }

    public void playGame()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void levelSelect()
    {
        menuRotation.showLevels();
    }

    public void level_1()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void level_2()
    {
        SceneManager.LoadScene("Level_2");
    }

    public void level_3()
    {
        SceneManager.LoadScene("Level_3");
    }

    public void freeplay()
    {
        SceneManager.LoadScene("Freeplay");
    }

    public void howtoplay()
    {
        menuRotation.showHelp();
    }

    public void settings()
    {
        menuRotation.showSettings();
    }

    public void haptics()
    {
        hapticsEnabled = !hapticsEnabled;   // Flips the state of the bool each time it's called.

        if (hapticsEnabled)
        {
            enabledText.SetActive(true);
            disabledText.SetActive(false);
            api.EnableHaptics();
        }
        else
        {
            enabledText.SetActive(false);
            disabledText.SetActive(true);
            api.DisableHaptics();
        }
    }

    public void volUp()
    {

    }

    public void volDown()
    {

    }

    public void back()
    {
        menuRotation.showMain();
    }

    public void quit()
    {
        Application.Quit();
    }
}
