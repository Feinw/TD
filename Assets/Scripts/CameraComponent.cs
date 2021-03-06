﻿using UnityEngine;

public class CameraComponent : MonoBehaviour {

	private bool move = true;

	public float panSpeed = 30f;
	public float panBorder = 10f;
	public float scrollSpeed = 5f;

	public float minY = 10f;
	public float maxY = 80f;

	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Escape))
			move = !move;

		if(!move)
			return;

		if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorder){
			transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
		}
		if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s") || Input.mousePosition.y <= panBorder){
			transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
		}
		if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorder){
			transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
		}
		if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a") || Input.mousePosition.x <= panBorder){
			transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
		}

		float scroll = Input.GetAxis("Mouse ScrollWheel");
		Vector3 pos = transform.position;

		pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
		pos.y = Mathf.Clamp(pos.y, minY, maxY);

		transform.position = pos;
		
	}
}
