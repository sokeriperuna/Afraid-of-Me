using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	void Awake(){
		ExitTile.OnPlayerEnter += PlayerVictory;
        PlayerEntity.playerFailure += PlayerFailure;
	}

	void PlayerVictory(){
		SceneManager.LoadScene("Main");
	}

    void PlayerFailure()
    {
        SceneManager.LoadScene("Main");
    }
}
