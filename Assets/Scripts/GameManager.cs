using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject _teleport;
	public GameObject _deathScreen;

	private GameObject _currentPlayer;
	private Vector3 _checkpoint;
	private CameraFollow _cam;
	private float _distance; //Distance between DeadStart and Spawn;
	private GameObject _currentTeleport;
	private GameObject _currentScreen;
	private bool handle = true;

	public static int _levelCount = 2;
	public static int _currentLevel = 0;

	// Use this for initialization
	void Awake () {
		_cam = GetComponent<CameraFollow>();
		if(GameObject.FindGameObjectWithTag("Respawn")){
			GameObject _respawn = GameObject.FindGameObjectWithTag("Respawn");
			_checkpoint = new Vector3(_respawn.transform.position.x,_respawn.transform.position.y-_respawn.GetComponent<BoxCollider2D>().size.y/2,_respawn.transform.position.z);
			_distance = Mathf.Abs(_cam.deadStart.transform.position.x - _checkpoint.x);
		}		
		SpawnPlayer (_checkpoint);
	}

	// FixedUpdate is called every fixed framerate frame.
	void FixedUpdate(){ 
		if(GameObject.FindGameObjectWithTag("Player")){
			_currentPlayer = GameObject.FindGameObjectWithTag("Player");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(!_currentTeleport){
			if(!_currentPlayer){

				if(!_currentScreen&&handle){
					handle=false;
					_currentScreen = Instantiate (_deathScreen, Vector3.zero, Quaternion.identity) as GameObject;
				}
				if(!_currentScreen&&!handle){
					SpawnPlayer(_checkpoint);
					handle=true;
				}
				if(_cam.deadStart.transform.position.x > _checkpoint.x){
					_cam.deadStart.transform.position = new Vector3(_checkpoint.x -_distance, _cam.deadStart.transform.position.y,_cam.deadStart.transform.position.z);
				}
			}
		}
	}

	// LateUpdate is called after all Update functions have been called
	void LateUpdate(){

	}

	private void SpawnPlayer(Vector3 spawnPos){
		if(!_currentTeleport){
			_currentTeleport = Instantiate (_teleport, spawnPos, Quaternion.identity) as GameObject;
		}
	}

	public void SetCheckpoint(Vector3 cp){
		_checkpoint = cp;
	}

	// For load level
	public void EndLevel(){
		if(_currentLevel < _levelCount){
			_currentLevel++;
			Application.LoadLevel("Level" + _currentLevel);
		}
		else{
			Debug.Log("Game Over");
		}
	}
}
