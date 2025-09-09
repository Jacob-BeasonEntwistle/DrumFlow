using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BassDrum : MonoBehaviour
{
    public ZMQManager ZMQManager;

    [SerializeField] private EventReference BassDrumSound;

    private bool hasPlayed = false;

    // Update is called once per frame
    void Update()
    {
        playBassDrum();
    }

    private void playBassDrum()
    {
        if (ZMQManager.rightPressureData > 2 && !hasPlayed)
        {
            AudioManager.instance.PlayOneShot(BassDrumSound, this.transform.position);
            UnityEngine.Debug.Log("The bass drum was hit! Bommm");
            hasPlayed = true;
        }
        stopPlaying();
    }

    private void stopPlaying()
    {
        if (ZMQManager.rightPressureData < 2)
        {
            hasPlayed = false;
        }
    }
}
