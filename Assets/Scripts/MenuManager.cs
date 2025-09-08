using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    // References to necessary etee components.
    public etee.eteeAPI api;

    [Header ("Menu Screens")]
    public GameObject mainMenu;
    public GameObject levelMenu;
    public GameObject settingsMenu;

    public GameObject currentScreen;

    public Toggle toggle;

    // Start is called before the first frame update
    void Start()
    {
        ShowScreen(mainMenu);
    }

    void Update()
    {
        if (currentScreen != mainMenu && Input.GetKey(KeyCode.Escape))
        {
            ShowScreen(mainMenu);
        }
    }

    public void ShowScreen(GameObject ScreenToShow)
    {
        if (currentScreen != null)
        {
            currentScreen.SetActive(false);
        }

        ScreenToShow.SetActive(true);
        currentScreen = ScreenToShow;
    }

    public void playGame()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void levelSelect()
    {
        ShowScreen(levelMenu);
    }

    public void settings()
    {
        ShowScreen(settingsMenu);
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

    public void quit()
    {
        Application.Quit();
    }
}
