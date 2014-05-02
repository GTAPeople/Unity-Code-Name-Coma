using UnityEngine;
using System.Collections;

public class FinishLevel : MonoBehaviour {
	private GameManager _manager;

	// Use this for initialization
	void Start () {
		_manager = Camera.main.GetComponent<GameManager> ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			_manager.EndLevel();
		}
	}
}
