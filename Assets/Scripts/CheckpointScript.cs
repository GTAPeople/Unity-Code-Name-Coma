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
			_manager.SetCheckpoint(new Vector3(transform.position.x, transform.position.y-GetComponent<BoxCollider2D>().size.y/2,transform.position.z));
			collider2D.enabled = false;
		}
	}
}
