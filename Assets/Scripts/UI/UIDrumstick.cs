using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class UIDrumstick : Drumstick
{
    private MenuButton currentButton;

    // Used to set which part of the drum kit is currently selected.
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MenuButton"))
        {
            UnityEngine.Debug.Log("Entered menu button collider: " + other.name);
            currentButton = other.GetComponent<MenuButton>();
        }
    }

    // A method that plays the instrument depending on if the controller is squeezed and the drum has not been played.
    public override void UpdateSqueeze(bool squeeze)
    {
        // Squeezing while over a button.
        if (squeeze && !hasPlayed && currentButton != null)
        {
            currentButton.PressButton();
            PlaySnareUI();
            hasPlayed = true;
        }
        // Releasing squeeze.
        if (!squeeze)
        {
            hasPlayed = false;
        }
        isSqueezing = squeeze;
    }

    // Used to deselect any parts of the drumkits once the collider is exited.
    protected void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MenuButton"))
        {
            if (currentButton != null && other.gameObject == currentButton.gameObject)
            {
                currentButton = null;
            }
        }
    }

    // A function to play each sound of the drum kit.
    private void PlaySnareUI()
    {
        AudioManager.instance.PlayOneShot(SnareSound, this.transform.position);
        UnityEngine.Debug.Log("The Snare drum was hit! Ckk");
    }
}
