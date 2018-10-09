using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrap : MonoBehaviour {

	public static int cash;
	public int startCash = 400;

	public static int lives;
	public int start_lives = 20;

	void Start(){
		cash = startCash;
		lives = start_lives;
	}

}
