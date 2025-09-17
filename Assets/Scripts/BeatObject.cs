using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* [--- This script allows a beat to be played when it collides with each part of the drum kit. ---] */
public class BeatObject : MonoBehaviour
{
    // References to necessary etee components.
    public etee.eteeAPI api;

    public bool canBePressed;
    private string currentDrumTag = "";

    void Start()
    {
        api = GameObject.Find("/ContinuousObject/eteeAPI/API").GetComponent<etee.eteeAPI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!canBePressed) return;

        // When one of the controllers are squeezed...
        if ((api.GetIsSqueezeGesture(0) == true && (currentDrumTag == "hihat" || currentDrumTag == "snare")) || (api.GetIsSqueezeGesture(1) == true && (currentDrumTag == "midTom" || currentDrumTag == "ride")))
        {
            // the beat is played and set inactive.
            gameObject.SetActive(false);

            GameManager.instance.BeatHit();
        }
    }

    // When the beat enters the collision area of any part of the drum kit...
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("hihat") || other.CompareTag("snare") || other.CompareTag("midTom") || other.CompareTag("ride"))
        {
            // the beat can be pressed.
            canBePressed = true;
            currentDrumTag = other.tag;
        }
    }

    // When the beat exits the collision area of any part of the drum kit...
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == currentDrumTag)
        {
            // the beat can no longer be pressed.
            canBePressed = false;
            currentDrumTag = "";

            GameManager.instance.BeatMissed();
        }
    }
}
