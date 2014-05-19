using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject _teleport;
	private GameObject _currentPlayer;
	private Vector3 _checkpoint;
	private CameraFollow _cam;
	private float _distance; //Distance between DeadStart and Spawn;
	private GameObject _currentTeleport;

	public static int _levelCount = 2;
	public static int _currentLevel = 0;

	// Use this for initialization
	void Start () {
		_cam = GetComponent<CameraFollow>();
		if(GameObject.FindGameObjectWithTag("Respawn")){
			GameObject _respawn = GameObject.FindGameObjectWithTag("Respawn");
			_checkpoint = new Vector3(_respawn.transform.position.x,_respawn.transform.position.y-_respawn.GetComponent<BoxCollider2D>().size.y/2,_respawn.transform.position.z);
			_distance = Mathf.Abs(_cam.deadStart.transform.position.x - _checkpoint.x);
		}		
		SpawnPlayer (_checkpoint);
	}
	
	// Update is called once per frame
	void Update () {
		if(!_currentPlayer){
			SpawnPlayer(_checkpoint);
			if(_cam.deadStart.transform.position.x > _checkpoint.x){
				_cam.deadStart.transform.position = new Vector3(_checkpoint.x -_distance, _cam.deadStart.transform.position.y,_cam.deadStart.transform.position.z);
			}
		}
	}

	private void SpawnPlayer(Vector3 spawnPos){
		if(!_currentTeleport){
			_currentTeleport = Instantiate (_teleport, spawnPos, Quaternion.identity) as GameObject;
		}
		if(GameObject.FindGameObjectWithTag("Player")){
			_currentPlayer = GameObject.FindGameObjectWithTag("Player");
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
