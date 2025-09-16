using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using FMODUnity;


/* [--- This script is used to handle the behaviour of a single drumstick. ---] */
public class Drumstick : MonoBehaviour
{
    // Allows you to enter the different sounds that the drum kit is supposed to make.
    [SerializeField] protected EventReference ClosedHihatSound;
    [SerializeField] protected EventReference SnareSound;
    [SerializeField] protected EventReference MidTomSound;
    [SerializeField] protected EventReference RideSound;

    protected string currentBox = null;       // String to store the current collision box.
    protected bool hasPlayed = false;         // Bool to check whether the instrument has been played.
    protected bool isSqueezing = false;       // Bool to check if the controller is squeezing.

    // A method that updates the rotation of the drumstick.
    public virtual void UpdateRotation(Quaternion rotation)
    {
        transform.rotation = rotation;
    }

    // A method that plays the instrument depending on if the controller is squeezed and the drum has not been played.
    public virtual void UpdateSqueeze(bool squeeze)
    {
        if (squeeze && !hasPlayed && currentBox != null)
        {
            PlayInstrument(currentBox);
            hasPlayed = true;
        }
        else if (!squeeze)
        {
            hasPlayed = false;
        }
        isSqueezing = squeeze;
    }

    // Used to set which part of the drum kit is currently selected.
    protected virtual void OnTriggerEnter(Collider other)
    {
        UnityEngine.Debug.Log("Entered collider: " + other.tag);
        if (other.CompareTag("hihat") || other.CompareTag("snare") || other.CompareTag("midTom") || other.CompareTag("ride"))
        {
            currentBox = other.tag;
        }
    }

    // Used as a backup to ensure the drumstick constantly knows which drum it's colliding with.
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("hihat") || other.CompareTag("snare") || other.CompareTag("midTom") || other.CompareTag("ride"))
        {
            currentBox = other.tag;
        }
    }

    // Used to deselect any parts of the drumkits once the collider is exited.
    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.tag == currentBox)
        {
            currentBox = null;
        }
    }

    // A function to play each sound of the drum kit.
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
