using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using FMODUnity;

public class DrumstickMovement : MonoBehaviour
{
    public etee.eteeDevice device;
    public etee.eteeAPI api;

    [SerializeField] private EventReference ClosedHihatSound;
    [SerializeField] private EventReference SnareSound;
    [SerializeField] private EventReference MidTomSound;
    [SerializeField] private EventReference RideSound;

    private string currentBoxL = null;   // Which drum or cymbal the left drumstick is inside of.
    private string currentBoxR = null;   // Which drum or cymbal the right drumstick is inside of.

    private bool leftPlayed = false;
    private bool rightPlayed = false;

    // Update is called once per frame
    void Update()
    {
        // If it's the left device...
        if (device.isLeft == true)
        {
            // Get the rotations of the left controller...
            Vector3 LcontrollerAngles = api.GetRotations(0);
            // Assign the yaw to a variable...
            float yaw = LcontrollerAngles.x;
            // Set the transform rotation of the left drumstick to that yaw.
            transform.rotation = Quaternion.Euler(54, -29, yaw);
        }
        // If it's the right device...
        if (device.isLeft == false)
        {
            // Get the rotations of the right controller...
            Vector3 RcontrollerAngles = api.GetRotations(1);
            // Assign the yaw to a variable...
            float yaw = RcontrollerAngles.x;
            // Set the transform rotation of the right drumstick to that yaw.
            transform.rotation = Quaternion.Euler(47, 55, yaw);
        }

        // Bools to check if the controller is squeezing.
        bool LSqueezing = api.GetIsSqueezeGesture(0);
        bool RSqueezing = api.GetIsSqueezeGesture(1);
        UnityEngine.Debug.Log("LSqueezing: " + LSqueezing + ", RSqueezing: " + RSqueezing);

        if (currentBoxL != null && LSqueezing && !leftPlayed)
        {
            PlayInstrument(currentBoxL);
            leftPlayed = true;
            UnityEngine.Debug.Log("Left controller squeezed. Current sound: " + currentBoxL);
        }
        if (currentBoxR != null && RSqueezing && !rightPlayed)
        {
            PlayInstrument(currentBoxR);
            rightPlayed = true;
            UnityEngine.Debug.Log("Right controller squeezed. Current sound: " + currentBoxR);
        }

        if (!LSqueezing && leftPlayed) leftPlayed = false;
        if (!RSqueezing && rightPlayed) rightPlayed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        UnityEngine.Debug.Log("Entered collider: " + other.tag);
        if (other.CompareTag("hihat") || other.CompareTag("snare") || other.CompareTag("midTom") || other.CompareTag("ride"))
        {
            if (device.isLeft)
            {
                currentBoxL = other.tag;
            }
            else
            {
                currentBoxR = other.tag;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (device.isLeft && other.tag == currentBoxL)
        {
            currentBoxL = null;
        }
        if (!device.isLeft && other.tag == currentBoxR)
        {
            currentBoxR = null;
        }
    }


    private void PlayInstrument(string drumTag)
    {
        switch (drumTag)
        {
            case "hihat":
                AudioManager.instance.PlayOneShot(ClosedHihatSound, this.transform.position);
                UnityEngine.Debug.Log("The Hi-hat was hit! Tss");
                break;
            case "snare":
                AudioManager.instance.PlayOneShot(SnareSound, this.transform.position);
                UnityEngine.Debug.Log("The Snare drum was hit! Ckk");
                break;
            case "midTom":
                AudioManager.instance.PlayOneShot(MidTomSound, this.transform.position);
                UnityEngine.Debug.Log("The Mid Tom was hit! Dooo");
                break;
            case "ride":
                AudioManager.instance.PlayOneShot(RideSound, this.transform.position);
                UnityEngine.Debug.Log("The Ride cymbal was hit! Tshh");
                break;
        }
    }
}
