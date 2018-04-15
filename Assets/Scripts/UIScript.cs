using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

    public Text mirrorBufferText;
    public PlayerEntity player;

    private void Awake()
    {
        player.mirrorBufferUpdated += UpdateMirrorBufferText;
    }

    void UpdateMirrorBufferText()
    {
        mirrorBufferText.text = "MB: " + player.mirrorBuffer;
    }
}
