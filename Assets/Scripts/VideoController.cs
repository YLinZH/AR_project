using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Button controlButton;
    private bool isPlaying = true;

    void Start()
    {
        // Add listener to the button
        controlButton.onClick.AddListener(ToggleVideoPlayback);
    }

    void ToggleVideoPlayback()
    {
        if (isPlaying)
        {
            videoPlayer.Pause();
            controlButton.GetComponentInChildren<Text>().text = "Paused..."; // Update button text
        }
        else
        {
            videoPlayer.Play();
            controlButton.GetComponentInChildren<Text>().text = ""; // Update button text
        }
        isPlaying = !isPlaying;
    }
}

