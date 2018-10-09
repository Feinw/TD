using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

	public Color hovercolor;
	public Color noMoney;
	public Vector3 positionOffset;

	[Header("Optional")]
	public GameObject turret;

	private Renderer rend;
	private Color startColor;

	BuildManager buildManager;

	void Start(){
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;
	}

	void OnMouseDown(){

		if(EventSystem.current.IsPointerOverGameObject())
			return;

		if(!BuildManager.instance.can_build)
			return;

		if(turret != null){
			Debug.Log("Nope!");
			return;
		}
		BuildManager.instance.BuildTurretOn(this);
	}

	void OnMouseEnter(){
		if(EventSystem.current.IsPointerOverGameObject())
			return;

		if(!BuildManager.instance.can_build)
			return;

		if(BuildManager.instance.has_money){
			rend.material.color = hovercolor;
		}else{
			rend.material.color = noMoney;
		}
	}

	void OnMouseExit(){
		rend.material.color = startColor;
	}
}
