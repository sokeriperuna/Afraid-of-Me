using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class CameraScript : MonoBehaviour {

    public VideoClip jumpscare;
    public VideoClip winClip;

    private VideoPlayer videoPlayer;

    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        PlayerEntity.playerFailure += PlayJumpscare;
        GameManager.
    }

    private void PlayJumpscare()
    {
        videoPlayer.clip = jumpscare;
        videoPlayer.Play();
    }
}
