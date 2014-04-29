using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject _player;
	private GameObject _currentPlayer;
	private Vector3 _checkpoint;
	private CameraFollow _cam;
	private float _distance; //Distance between DeadStart and Spawn;

	// Use this for initialization
	void Start () {
		_cam = GetComponent<CameraFollow>();
		if(GameObject.FindGameObjectWithTag("Respawn")){
			_checkpoint = GameObject.FindGameObjectWithTag("Respawn").transform.position;
			_distance = Mathf.Abs(_cam.deadStart.transform.position.x - _checkpoint.x);
		}
		
		SpawnPlayer (_checkpoint);
	}
	
	// Update is called once per frame
	void Update () {
		if(!_currentPlayer){
			SpawnPlayer(_checkpoint);
			_cam.deadStart.transform.position = new Vector3(_checkpoint.x -_distance, _cam.deadStart.transform.position.y,_cam.deadStart.transform.position.z);
		}
	}

	private void SpawnPlayer(Vector3 spawnPos){
		_currentPlayer = Instantiate (_player, spawnPos, Quaternion.identity) as GameObject;
	}

	public void SetCheckpoint(Vector3 cp){
		_checkpoint = cp;
	}
}
