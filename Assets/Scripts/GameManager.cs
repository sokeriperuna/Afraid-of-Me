using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

<<<<<<< HEAD
	public Potion[] potions;

	private int collectedPotionCount;
=======
    public PotionScript[] potions;
>>>>>>> parent of 2d23318... Minor changes

	void Awake(){
		ExitTile.OnPlayerEnter += PlayerVictory;
        PlayerEntity.playerFailure += PlayerFailure;
		foreach (Potion potion in potions) 
		{
			potion.PotionCollectEvent += OnPotionCollect;
		}
	}

	void OnPotionCollect()
	{
		collectedPotionCount++;
		if (collectedPotionCount >= potions.Length)
			PlayerVictory ();
	}

	void PlayerVictory(){
		SceneManager.LoadScene("Main");
	}

    void PlayerFailure()
    {
        SceneManager.LoadScene("Main");
    }
}
