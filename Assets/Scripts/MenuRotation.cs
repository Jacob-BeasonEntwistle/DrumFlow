using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MenuRotation : MonoBehaviour
{
    public float rotationSpeed = 80f;

    // Different rotations for each camera direction.
    private Quaternion mainRotation;
    private Quaternion levelRotation;
    private Quaternion settingsRotation;
    private Quaternion howtoplayRotation;

    private Quaternion targetRotation;

    // Start is called before the first frame update
    void Start()
    {
        mainRotation = this.transform.rotation;
        levelRotation = Quaternion.Euler(mainRotation.eulerAngles + new Vector3(0, -135, 0));
        settingsRotation = Quaternion.Euler(mainRotation.eulerAngles + new Vector3(0, 110, 0));
        howtoplayRotation = Quaternion.Euler(mainRotation.eulerAngles + new Vector3(180, 0, 0));

        targetRotation = mainRotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    public void showMain()
    {
        targetRotation = mainRotation;
    }

    public void showLevels()
    {
        targetRotation = levelRotation;
    }

    public void showSettings()
    {
        targetRotation = settingsRotation;
    }

    public void showHelp()
    {
        targetRotation = howtoplayRotation;
    }
}
