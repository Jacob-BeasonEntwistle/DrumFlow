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

    public Toggle toggle;

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

    public void settings()
    {
        menuRotation.showSettings();
    }

    public void haptics()
    {
        if (toggle.isOn)
        {
            api.EnableHaptics();
        }

        if (!toggle.isOn)
        {
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
