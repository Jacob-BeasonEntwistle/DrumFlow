using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempFreeplayManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            AudioManager.instance.StopAllAudio();
            SceneManager.LoadScene("MainMenu");
        }
    }
}
