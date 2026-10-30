using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class IntroVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    private bool canSkip = false;
    private bool hasLoaded = false;

    void Awake()
    {
        videoPlayer.isLooping = false;
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        videoPlayer.Play();
        Invoke(nameof(EnableSkip), 0.2f); // Prevents instant skip
    }

    // Update is called once per frame
    void Update()
    {
        if (!canSkip || hasLoaded)
        {
            return;
        }

        if (Input.anyKeyDown)
        {
            LoadNextScene();
        }
    }

    void EnableSkip()
    {
        canSkip = true;
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        LoadNextScene();
    }

    void LoadNextScene()
    {
        if (hasLoaded) return;

        hasLoaded = true;
        SceneManager.LoadScene("MainMenu");
    }
}