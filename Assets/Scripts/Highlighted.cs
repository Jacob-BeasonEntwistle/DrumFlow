using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* [--- This script is for highlighting the different parts of the drum kit when the drumsticks are hovering above them. ---] */
public class Highlighted : MonoBehaviour
{
    // Creating references to the materials.
    public Material original;
    public Material highlighted;
    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        // Get the drum kit part's renderer and set its current material to its original state.
        rend = GetComponent<Renderer>();
        rend.material = original;
    }

    // When the collider is triggered on entry...
    private void OnTriggerEnter(Collider other)
    {
        // and the colliding object is the drumstick...
        if (other.CompareTag("drumstick"))
        {
            // highlight the drumstick part.
            rend.material = highlighted;
        }
    }

    // When the collider is triggered on exit...
    private void OnTriggerExit(Collider other)
    {
        // and the colliding object is the drumstick...
        if (other.CompareTag("drumstick"))
        {
            // return the drumstick part to its original state.
            rend.material = original;
        }
    }
}
