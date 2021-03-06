using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {
	public float xMin = -5f, xMax = 8f, yMin = -7f, yMax = 8f;
}


public class CameraController : MonoBehaviour {

	public GameObject player;
	public Boundary boundary;

	void Start() {
		transform.position = player.transform.position;
	}

	void LateUpdate() {
		transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -5);
		var v3 = transform.position;
		v3.x = Mathf.Clamp(v3.x, boundary.xMin, boundary.xMax);
		v3.y = Mathf.Clamp(v3.y, boundary.yMin, boundary.yMax);
		transform.position = v3;
	}
}
