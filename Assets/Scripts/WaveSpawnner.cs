using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawnner : MonoBehaviour {

	public Transform enemyPrefab;
	public Transform spawnpoint;

	public float cdtimer = 5.5f;
	private float cd = 2f;

	public Text wavecdtext;

	private int waveindex = 0;

	void Update () {
		if(cd<=0f){
			StartCoroutine(spawn());
			cd = cdtimer;
		}		
		cd -= Time.deltaTime;

		cd = Mathf.Clamp(cd, 0f, Mathf.Infinity);

		wavecdtext.text = string.Format("{0:00.00}", cd);

	}
	IEnumerator spawn(){
		waveindex++;
		for(int i = 0; i < waveindex; i++){
			spawne();
			yield return new WaitForSeconds(0.5f);
		}
	}
	void spawne(){
		Instantiate(enemyPrefab,spawnpoint.position,spawnpoint.rotation);
	}
}
