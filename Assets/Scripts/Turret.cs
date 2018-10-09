using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	private Transform target;
	
	[Header("Attributes")]
	public float range = 15f;
	public float firerate = 1f;
	private float firecd = 0f;

	[Header("Enemy Setup")]
	public string enemyTag = "Enemy";
	public Transform partRotate;
	public float turnspeed = 10f;

	public GameObject bulletprefab;
	public Transform firepoint;

	// Use this for initialization
	void Start () {
		InvokeRepeating("updateTarget", 0f, 0.5f);
	}
	
	void updateTarget () {

		GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
		float shorterst = Mathf.Infinity;
		GameObject nearest = null;

		foreach(GameObject enemy in enemies){
			float distance_to_enemy = Vector3.Distance(transform.position, enemy.transform.position);
			if(distance_to_enemy < shorterst){
				shorterst = distance_to_enemy;
				nearest = enemy;
			}
		}

		if(nearest != null && shorterst <= range){
			target = nearest.transform;
		}else{
			target = null;
		}

	}

	// Update is called once per frame
	void Update () {
		if(target == null)
			return;

		Vector3 dir = target.position - transform.position;
		Quaternion lookRotate = Quaternion.LookRotation(dir);
		Vector3 actual_rotation = Quaternion.Lerp(partRotate.rotation, lookRotate, Time.deltaTime * turnspeed).eulerAngles;
		partRotate.rotation = Quaternion.Euler(0f, actual_rotation.y, 0f);

		if(firecd <= 0){
			Shoot();
			firecd = 1f/firerate;
		}

		firecd-=Time.deltaTime;
	}

	void Shoot(){
		GameObject bulletGO = (GameObject)Instantiate(bulletprefab,firepoint.position,firepoint.rotation);
		Bullet bullet = bulletGO.GetComponent<Bullet>();
		if(bullet!=null){
			bullet.seek(target);
		}
	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);
	}
}
