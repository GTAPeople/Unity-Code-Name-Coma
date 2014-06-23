using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {
	public GameObject _exitPortal;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player")){
			other.transform.position = _exitPortal.transform.position;
		}
	}
}
