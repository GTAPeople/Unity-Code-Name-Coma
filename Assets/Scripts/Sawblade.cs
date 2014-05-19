using UnityEngine;
using System.Collections;

public class Sawblade : MonoBehaviour {

	public float speed = 300f;
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.forward*speed*Time.deltaTime,Space.World);
	}
}
