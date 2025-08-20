using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using FMODUnity;

public class DrumHit : MonoBehaviour
{
    public etee.eteeAPI api;
    [SerializeField] private EventReference ClosedHihatSound;
    [SerializeField] private EventReference SnareSound;

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
        float leftSwing = api.GetAccelerometerSingleAxis(0, 'y');     // Left controller
        float rightSwing = api.GetAccelerometerSingleAxis(1, 'y');     // Right controller

        if (rightSwing < -1)
        {
            hihatHit();
        }

        if (leftSwing < -1)
        {
            AudioManager.instance.PlayOneShot(SnareSound, this.transform.position);
            UnityEngine.Debug.Log("The Snare drum was hit! Ckk");
        }
    }

    void hihatHit()
    {
        AudioManager.instance.PlayOneShot(ClosedHihatSound, this.transform.position);
        UnityEngine.Debug.Log("The Hi-hat was hit! Tss");
    }
}
