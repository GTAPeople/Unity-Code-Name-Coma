using UnityEngine;
using System.Collections;

public class CheckpointScript : MonoBehaviour {
	private GameManager _manager;

	// Use this for initialization
	void Start () {
		_manager = Camera.main.GetComponent<GameManager> ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player")){
			_manager.SetCheckpoint(transform.position);
			collider2D.enabled = false;
		}
		// Test for Finish level
		//		if(other.tag == "Finish"){
		//			_manager.EndLevel();
		//		}
	}
}
