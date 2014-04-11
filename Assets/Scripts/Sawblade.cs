using UnityEngine;
using System.Collections;

public class Sawblade : MonoBehaviour {

	public float speed = 300f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.forward*speed*Time.deltaTime,Space.World);
	}

	void OnTriggerEnter2D(Collider2D c){
		if(c.tag =="Player"){
			Debug.Log("DIE!");
		}
	}
}
