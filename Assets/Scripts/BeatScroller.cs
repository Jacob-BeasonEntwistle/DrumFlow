using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

/* [--- This script moves the beats towards the drum kit after the game is started. ---] */
public class BeatScroller : MonoBehaviour
{
    // References to necessary etee components.
    public etee.eteeAPI api;

    // The pace of the song.
    public float beatTempo;
    // Whether the game has started or not.
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
