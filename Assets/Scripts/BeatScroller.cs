using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

/* [--- This script moves the beats towards the drum kit after the game is started ---] */
public class BeatScroller : MonoBehaviour
{
    public etee.eteeAPI api;

    public float beatTempo;

    public bool hasStarted;

    // Start is called before the first frame update
    void Start()
    {
        // This calculates how fast the beats should be moving towards the drum kit.
        beatTempo = beatTempo / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        // If the game hasn't yet started...
        if (!hasStarted) return;
        else
        {
            // This moves beats towards the player at the speed set in the Start function.
            transform.position -= new Vector3(0f, 0f, beatTempo * Time.deltaTime);
        }
    }
}
