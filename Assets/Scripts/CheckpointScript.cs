using UnityEngine;
using System.Collections;

public class CheckpointScript : MonoBehaviour {
	private GameManager _manager;
	private bool[] _checkBool;
	private Vector3[] _checkVector;
	private int _totalLevel = 10;

	// Use this for initialization
	void Start () {
		_manager = Camera.main.GetComponent<GameManager> ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if(PlayerPrefsX.GetVector3("CheckSpawn")!=(new Vector3(transform.position.x, transform.position.y-GetComponent<BoxCollider2D>().size.y/2,transform.position.z))){
			if(other.CompareTag("Player")){
				collider2D.enabled = false;
				_manager.SetCheckpoint(new Vector3(transform.position.x, transform.position.y-GetComponent<BoxCollider2D>().size.y/2,transform.position.z));
				_manager.CountCheckpoint();
				_checkBool = PlayerPrefsX.GetBoolArray ("LevelBool",false,_totalLevel);
				_checkVector = PlayerPrefsX.GetVector3Array ("CheckVector",new Vector3(0,0,0),_totalLevel);
				_checkBool[_manager.GetCountCheckpoint()-1] = true;
				_checkVector[_manager.GetCountCheckpoint()-1] = new Vector3(transform.position.x, transform.position.y-GetComponent<BoxCollider2D>().size.y/2,transform.position.z);
				PlayerPrefsX.SetBoolArray("LevelBool",_checkBool);
				PlayerPrefsX.SetVector3Array("CheckVector",_checkVector);
			}
		}
	}
}
