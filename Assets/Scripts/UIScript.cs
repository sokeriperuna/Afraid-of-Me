using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

    public Text mirrorBufferText;
    public Text potionsCollectedText;
    public PlayerEntity player;

    public Potion[] potions;

    public int potionsCollected;

    private void Start()
    {
        potionsCollected = 0;
        player.mirrorBufferUpdated += UpdateMirrorBufferText;
        foreach (Potion potion in potions)
        {
            potion.PotionCollectEvent += OnPotionCollect;
        }

        potionsCollectedText.text = ("Potions collected: " + potionsCollected.ToString() + "/" + potions.Length.ToString());
    }

    void OnPotionCollect()
    {
        potionsCollected++;
        potionsCollectedText.text = ("Potions collected: " + potionsCollected.ToString() + "/" + potions.Length.ToString());
    }

    void UpdateMirrorBufferText()
    {
        mirrorBufferText.text = "MB: " + player.mirrorBuffer;
    }
}
