using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDrumstick : MonoBehaviour
{
    // References to necessary etee components.
    public etee.eteeDevice leftDevice;
    public etee.eteeDevice rightDevice;
    public etee.eteeAPI api;

    // Update is called once per frame
    void Update()
    {
        // Gets the rotations of the left controller.
        Vector3 LcontrollerAngles = api.GetRotations(0);
        // Updates the left sticks rotations to that of the controller.
        UpdateRotation(Quaternion.Euler(0, 0, LcontrollerAngles.x));

        // Get the rotations of the right controller...
        Vector3 RcontrollerAngles = api.GetRotations(1);
        // Updates the right sticks rotations to that of the controller.
        UpdateRotation(Quaternion.Euler(0, 0, RcontrollerAngles.x));
    }

    public void UpdateRotation(Quaternion rotation)
    {
        transform.rotation = rotation;
    }
}
