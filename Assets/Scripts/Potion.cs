using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Potion : MonoBehaviour {

	public delegate void PotionDelegate();
	public event PotionDelegate PotionCollectEvent;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Player")) 
		{
			if (PotionCollectEvent != null)
				PotionCollectEvent ();

            gameObject.SetActive(false);
		}
	}
}
