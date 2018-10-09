using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;

	void Awake(){
		instance = this;
	}

	public GameObject standardTurret; 
	public GameObject MissileLauncher; 	
	public GameObject buildEffect;

	private TurretBlueprint turrettobuild;

	public bool can_build{get{return turrettobuild != null;}}
	public bool has_money{get{return PlayerCrap.cash >= turrettobuild.cost;}}

	public void selectTurrettoBuild (TurretBlueprint turret){
		turrettobuild = turret;
	}

	public void BuildTurretOn(Node node){
		if(PlayerCrap.cash < turrettobuild.cost){
			Debug.Log("no");
			return;
		}

		PlayerCrap.cash -= turrettobuild.cost;

		GameObject turret = (GameObject)Instantiate(turrettobuild.prefab, node.transform.position + node.positionOffset, Quaternion.identity);
		node.turret = turret;

		GameObject effect = (GameObject)Instantiate(buildEffect, node.transform.position + node.positionOffset, Quaternion.identity);
		Destroy(effect, 5f);

		Debug.Log("money: "+PlayerCrap.cash);
	}
}
