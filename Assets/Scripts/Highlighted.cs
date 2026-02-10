using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* [--- This script is for highlighting the different parts of the drum kit when the drumsticks are hovering above them. ---] */
public class Highlighted : MonoBehaviour
{
    // Creating references to the materials.
    public Material original;
    private Renderer rend;
    private bool changeOpacity;
    private Color c;

    // Start is called before the first frame update
    void Start()
    {
        // Get the drum kit part's renderer and set its current material to its original state.
        rend = GetComponent<Renderer>();
        rend.material = original;

        c = rend.material.color;

        changeOpacity = true;

        // If the current object is a beat...
        if (gameObject.CompareTag("beat"))
        {
            // set the beat's opacity.
            c.a = 1.0f;
            rend.material.color = c;

            changeOpacity = false;
        }
    }

    // When the collider is triggered on entry...
    private void OnTriggerEnter(Collider other)
    {
        // If the colliding object is the drumstick...
        if (changeOpacity && other.CompareTag("drumstick"))
        {
            // change the beat's opacity.
            c.a = 0.8f;
            rend.material.color = c;
        }
    }

    // When the collider is triggered on exit...
    private void OnTriggerExit(Collider other)
    {
        // and the colliding object is the drumstick...
        if (changeOpacity && other.CompareTag("drumstick"))
        {
            // return the drumstick part to its original state.
            c.a = 0.2f;
            rend.material.color = c;
        }
    }
}
