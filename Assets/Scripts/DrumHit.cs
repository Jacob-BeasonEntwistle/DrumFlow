using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class DrumHit : MonoBehaviour
{
    public etee.eteeAPI api;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //// Retrieve left and right hand finger pull data
        //float[] leftPullData = api.GetAllFingersPull(0);
        //float[] rightPullData = api.GetAllFingersPull(1);

        //// Print index values in terminal
        //UnityEngine.Debug.Log("Left Index Pull Pressure: " + leftPullData[1]);
        //UnityEngine.Debug.Log("Right Index Pull Pressure: " + rightPullData[1]);

        // Retrieve down swing for controllers
        float leftSwingDown = api.GetAccelerometerSingleAxis(0, 'y');     // Left controller
        float rightSwingDown = api.GetAccelerometerSingleAxis(1, 'y');     // Right controller

        if (rightSwingDown < -1)
        {
            hihatHit();
        }
    }

    void hihatHit()
    {
        UnityEngine.Debug.Log("The Hi-hat was hit! Tss");
    }
}
