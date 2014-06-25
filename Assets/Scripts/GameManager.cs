using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject _teleport;
	public GameObject _deathScreen;
	public GameObject _luz;

	private GameObject _currentPlayer;
	private Vector3 _checkpoint;
	private CameraFollow _cam;
	private float _distance; //Distance between DeadStart and Spawn;
	private GameObject _currentTeleport;
	private GameObject _currentScreen;
	private bool handle = true;
	private bool checkBG = false;
	private int _countCheck;

	private bool _StartGame = false;

	// Awake is used to initialize any variables or game state before the game starts
	void Awake () {
		_countCheck = PlayerPrefs.GetInt("CountCheck",0);
		_cam = GetComponent<CameraFollow>();
		if(PlayerPrefsX.GetVector3("CheckSpawn")==Vector3.zero){
			if(GameObject.FindGameObjectWithTag("Respawn")){
				GameObject _respawn = GameObject.FindGameObjectWithTag("Respawn");
				_checkpoint = new Vector3(_respawn.transform.position.x,_respawn.transform.position.y-_respawn.GetComponent<BoxCollider2D>().size.y/2,_respawn.transform.position.z);
				_distance = Mathf.Abs(_cam.deadStart.transform.position.x - _checkpoint.x);
			}	
		}else{
			_checkpoint = PlayerPrefsX.GetVector3("CheckSpawn");
			if(GameObject.FindGameObjectWithTag("Respawn")){
				GameObject _respawn = GameObject.FindGameObjectWithTag("Respawn");
				_distance = Mathf.Abs(_cam.deadStart.transform.position.x - _respawn.transform.position.x);
			}
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
				_cam.deadStart.transform.position = new Vector3(_checkpoint.x -_distance, _cam.deadStart.transform.position.y,_cam.deadStart.transform.position.z);
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
		Instantiate(_luz, new Vector3(spawnPos.x,-1.190162f,0.0f), Quaternion.identity);
		if(_StartGame == false)
		{
			InvokeRepeating("CreateLight", 0.1f, 0.1f);
			_StartGame = true;
		}

	}

	private void CreateLight(){
		Vector3 lightPosition = PlayerPrefsX.GetVector3 ("OldLevelLight",new Vector3(-12,1,0));

		//Debug.Log("LP:" + lightPosition.x);

		bool status = PlayerPrefsX.GetBool("PlayerStatus", true);
		if(status)
		{
			bool nearLight = false;
			GameObject[] lights = GameObject.FindGameObjectsWithTag ("ColaLuz");
			float menor = 99999999999.0f;
			for(int i = 0; i < lights.Length; i++)
			{
				//Debug.Log("--- " + (lightPosition.x - lights[i].transform.position.x));
				if(lights[i].transform.position.x < menor)
				{
					menor = lights[i].transform.position.x;
				}

			}

			Debug.Log("--- " + (menor - lightPosition.x));
			if(Mathf.Abs(menor - lightPosition.x) < 20)
			{
				nearLight = true;
			}



			if(!nearLight)
			{
				Instantiate(_luz, lightPosition, Quaternion.identity);
			}

			//Instantiate(_luz, lightPosition, Quaternion.identity);
		}

	}

	// A public method for Checkpoint script only
	public void SetCheckpoint(Vector3 cp){
		_checkpoint = cp;
	}

	// A public method for Checkpoint script only
	public void CountCheckpoint(){
		_countCheck ++;
	}

	// A public method for Checkpoint and ParallaxBackgroundSky script only
	public int GetCountCheckpoint(){
		return _countCheck;
	}

	// A public method for DeathScreen script only
	public void TryCameraToFindLastCheckpoint(){
		_cam.moveToLastCheckpoint ();
	}

	// A public method for ParallaxScrollingBG script only
	public Vector3 GetCheckpoint(){
		return _checkpoint;
	}

	// A public method for ParallaxScrollingBG and DeathScreen script only
	public void SetCheckBG(bool _check){
		checkBG = _check;
	}

	// A public method for ParallaxScrollingBG script only
	public bool GetCheckBG(){
		return checkBG;
	}
}
