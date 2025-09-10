using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    public enum ButtonAction
    {
        PlayGame,
        LevelSelect,
        Level_1,
        Level_2,
        Level_3,
        Level_4,
        Settings,
        Haptics,
        VolUp,
        VolDown,
        Back,
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
            case ButtonAction.Level_1:
                menuManager.level_1();
                break;
            case ButtonAction.Level_2:
                menuManager.level_2();
                break;
            case ButtonAction.Settings:
                menuManager.settings();
                break;
            case ButtonAction.Haptics:
                menuManager.haptics();
                break;
            case ButtonAction.VolUp:
                menuManager.volUp();
                break;
            case ButtonAction.VolDown:
                menuManager.volDown();
                break;
            case ButtonAction.Back:
                menuManager.back();
                break;
            case ButtonAction.Quit:
                menuManager.quit();
                break;
        }
    }
}
