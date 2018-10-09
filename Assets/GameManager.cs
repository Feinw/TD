using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	
	private bool end = false;

	// Update is called once per frame
	void Update () {
		if(end){
			return;
		}
		if(PlayerCrap.lives <= 0){
			EndGame();
		}		
	}

	void EndGame(){
		end = true;
		Debug.Log("Game Over");
	}
}
