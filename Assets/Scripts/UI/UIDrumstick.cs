using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDrumstick : MonoBehaviour
{
    // References to necessary etee components.
    public etee.eteeDevice leftDevice;
    public etee.eteeDevice rightDevice;
    public etee.eteeAPI api;

    public GameObject leftStick;
    public GameObject rightStick;

    // Update is called once per frame
    void Update()
    {
        // Gets the rotations of the left controller.
        Vector3 LcontrollerAngles = api.GetRotations(0);
        // Updates the left sticks rotations to that of the controller.
        LeftUpdateRotation(Quaternion.Euler(90, 0, LcontrollerAngles.x));

        // Get the rotations of the right controller...
        Vector3 RcontrollerAngles = api.GetRotations(1);
        // Updates the right sticks rotations to that of the controller.
        RightUpdateRotation(Quaternion.Euler(90, 0, RcontrollerAngles.x));
    }

    public void LeftUpdateRotation(Quaternion rotation)
    {
        leftStick.transform.rotation = rotation;
    }

    public void RightUpdateRotation(Quaternion rotation)
    {
        rightStick.transform.rotation = rotation;
    }
}
