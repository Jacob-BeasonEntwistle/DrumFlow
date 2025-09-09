using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    public enum ButtonAction
    {
        PlayGame,
        LevelSelect,
        Settings,
        Quit
    }

    public ButtonAction action;

    private MenuManager menuManager;

    // Start is called before the first frame update
    void Start()
    {
        menuManager = FindObjectOfType<MenuManager>();
    }

    public void PressButton()
    {
        if (menuManager == null) return;

        switch (action)
        {
            case ButtonAction.PlayGame:
                menuManager.playGame();
                break;
            case ButtonAction.LevelSelect:
                menuManager.levelSelect();
                break;
            case ButtonAction.Settings:
                menuManager.settings();
                break;
            case ButtonAction.Quit:
                menuManager.quit();
                break;
        }
    }
}
