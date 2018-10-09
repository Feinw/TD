using UnityEngine;

public class Shop : MonoBehaviour {

	public TurretBlueprint standardTurret;
	public TurretBlueprint MissileLauncher;

	public void SelectStandardTurret(){
		Debug.Log("ST");
		BuildManager.instance.selectTurrettoBuild(standardTurret);
	}

	public void SelectMissileLauncher(){
		Debug.Log("ML");
		BuildManager.instance.selectTurrettoBuild(MissileLauncher);
	}
}
