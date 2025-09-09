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

    [Header ("Menu Screens")]
    public GameObject mainMenu;
    public GameObject levelMenu;
    public GameObject settingsMenu;

    public GameObject currentScreen;

    public GameObject drumsticks;

    // References to the camera.
    public Camera GameCamera;
    private float speed = 1.0f;
    private float rotationThreshold = 0.1f;

    // Different rotations for each camera direction.
    private Quaternion mainRotation;
    private Quaternion levelRotation;
    private Quaternion settingsRotation;
    private Quaternion targetRotation;

    public Toggle toggle;

    // Start is called before the first frame update
    void Start()
    {
        GameCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        ShowScreen(mainMenu);

        // Default rotation.
        mainRotation = GameCamera.transform.rotation;
        // Level select rotation.
        levelRotation = Quaternion.Euler(mainRotation.eulerAngles + new Vector3(0, 135, 0));
        // Settings rotation.
        settingsRotation = Quaternion.Euler(mainRotation.eulerAngles + new Vector3(0, -135, 0));
        // Start at main menu.
        targetRotation = mainRotation;
    }

    void Update()
    {
        if (currentScreen != mainMenu && Input.GetKey(KeyCode.Escape))
        {
            ShowScreen(mainMenu);
            targetRotation = mainRotation;
        }

        RotateCamera();
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

    public void RotateCamera()
    {
        float angleDifference = Quaternion.Angle(GameCamera.transform.rotation, targetRotation);

        if (angleDifference > rotationThreshold)
        {
            GameCamera.transform.rotation = Quaternion.Lerp(GameCamera.transform.rotation, targetRotation, speed * Time.deltaTime);
        }
        else
        {
            GameCamera.transform.rotation = targetRotation;
        }
    }

    public void playGame()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void levelSelect()
    {
        ShowScreen(levelMenu);
        targetRotation = levelRotation;
    }

    public void settings()
    {
        ShowScreen(settingsMenu);
        targetRotation = settingsRotation;
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
