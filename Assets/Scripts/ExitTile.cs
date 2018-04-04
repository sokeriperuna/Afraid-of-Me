using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTile : Tile {

	public delegate void ExitTileDelegate();
	public static event ExitTileDelegate OnPlayerEnter;

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			if (OnPlayerEnter != null)
				OnPlayerEnter ();
			Debug.Log ("Player entered exit!");
		}
	}
}
