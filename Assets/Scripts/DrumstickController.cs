using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumstickController : MonoBehaviour
{
    // References to necessary etee components.
    public etee.eteeDevice leftDevice;
    public etee.eteeDevice rightDevice;
    public etee.eteeAPI api;

    // References to the individual drumsticks.
    public Drumstick leftStick;
    public Drumstick rightStick;

    // Update is called once per frame
    void Update()
    {
        // Gets the rotations of the left controller.
        Vector3 LcontrollerAngles = api.GetRotations(0);
        // Updates the left sticks rotations to that of the controller.
        leftStick.UpdateRotation(Quaternion.Euler(47, -48, LcontrollerAngles.x));
        // Updates the the left sticks squeeze value.
        leftStick.UpdateSqueeze(api.GetIsSqueezeGesture(0));

        // Get the rotations of the right controller...
        Vector3 RcontrollerAngles = api.GetRotations(1);
        // Updates the right sticks rotations to that of the controller.
        rightStick.UpdateRotation(Quaternion.Euler(44, 16, RcontrollerAngles.x));
        // Updates the right sticks squeeze value.
        rightStick.UpdateSqueeze(api.GetIsSqueezeGesture(1));
    }
}
