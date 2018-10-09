using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

	public float speed = 10f;

	public int health = 2;

	public int val = 50;

	public GameObject deathAnimation;

	private Transform target;
	private int wavepointIndex = 0;

	public void takeDamage(int amount){
		health -= amount;
		if(health <= 0){
			death();
		}
	}

	void death(){
		PlayerCrap.cash += val;

		GameObject effect = (GameObject)Instantiate(deathAnimation, transform.position, Quaternion.identity);
		Destroy(effect, 5f);
		
		Destroy(gameObject);
	}

	// Use this for initialization
	void Start () {
		target = waypoints.points[0];
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

		if (Vector3.Distance(transform.position, target.position) <= 0.3f){
			NextWaypoint();
		}

	}

	void NextWaypoint(){

		if(wavepointIndex >= waypoints.points.Length - 1){
			EndPath();
			return;
		}

		wavepointIndex++;
		target = waypoints.points[wavepointIndex];
	}

	void EndPath(){
		PlayerCrap.lives--;
		Destroy(gameObject);

	}
}
