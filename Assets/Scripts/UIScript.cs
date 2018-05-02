using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

    public Text mirrorBufferText;
    public Text potionsLeftText;
    public PlayerEntity player;

    public Potion[] potions;

    private int potionsLeft;

    private void Awake()
    {
        potionsLeft = 0;
        player.mirrorBufferUpdated += UpdateMirrorBufferText;
        foreach (Potion potion in potions)
        {
            potion.PotionCollectEvent += OnPotionCollect;
            potionsLeft++;
            potionsLeftText.text = ("Potions left: " + potionsLeft);
        }
    }

    void OnPotionCollect()
    {
        potionsLeft--;
        potionsLeftText.text = ("Potions left: " + potionsLeft);
    }

    void UpdateMirrorBufferText()
    {
        mirrorBufferText.text = "MB: " + player.mirrorBuffer;
    }
}
