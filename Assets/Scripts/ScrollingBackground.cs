﻿using UnityEngine;
using System.Collections;

public class ScrollingBackground : MonoBehaviour {
	public float speed = 0.4f;
	public Texture[] texture;

	private float vertExtent;		// The size of vertical of the screen.
	private float horzExtent;		// The size of horizontal of the screen.
	public GameObject secondQuad;
	public GameObject thirdQuad;
	private GameObject _currentPlayer;
	private GameManager _manager;
	private Texture originTexture ;

	// Use this for initialization
	void Start () {
		_manager = Camera.main.GetComponent<GameManager> ();
		originTexture = renderer.material.mainTexture;

		float minY = Mathf.Abs(Camera.main.GetComponent<CameraFollow>().minY);
		float maxY = Mathf.Abs(Camera.main.GetComponent<CameraFollow>().maxY);

		// LocalScale
		vertExtent = Camera.main.camera.orthographicSize*2;  
		horzExtent = vertExtent * Camera.main.pixelWidth / Camera.main.pixelHeight;
		transform.localScale = new Vector3 (horzExtent, vertExtent + minY + maxY, 1);
		secondQuad.transform.localScale = new Vector3 (horzExtent, vertExtent + minY + maxY, 1);
		thirdQuad.transform.localScale = new Vector3 (horzExtent, vertExtent + minY + maxY, 1);

		// Position
		transform.position = new Vector3(_manager.GetCheckpoint().x, transform.position.y, transform.position.z);
		secondQuad.transform.position = new Vector3 (transform.position.x+horzExtent,secondQuad.transform.position.y,secondQuad.transform.position.z);
		thirdQuad.transform.position = new Vector3 (secondQuad.transform.position.x+horzExtent,thirdQuad.transform.position.y,thirdQuad.transform.position.z);
	}

	// FixedUpdate is called every fixed framerate frame
	void FixedUpdate(){ 
		if(GameObject.FindGameObjectWithTag("Player")){
			_currentPlayer = GameObject.FindGameObjectWithTag("Player");
		}
	}
	
	// Update is called once per frame
	void Update () {
		float move = speed * Time.deltaTime;
		transform.Translate (Vector3.left*move,Space.World);
		secondQuad.transform.Translate (Vector3.left*move,Space.World);
		thirdQuad.transform.Translate (Vector3.left*move,Space.World);
		if(_currentPlayer){
			if(_currentPlayer.transform.position.x > (transform.position.x+(horzExtent*1.5))){
//				Debug.Log("Got first");
				transform.position= new Vector3(thirdQuad.transform.position.x + horzExtent ,transform.position.y, transform.position.z);
			}
			if(_currentPlayer.transform.position.x > (secondQuad.transform.position.x+(horzExtent*1.5))){
//				Debug.Log("Got second");
				secondQuad.transform.position= new Vector3(transform.position.x + horzExtent ,transform.position.y, transform.position.z);
			}
			if(_currentPlayer.transform.position.x > (thirdQuad.transform.position.x+(horzExtent*1.5))){
//				Debug.Log("Got third");
				thirdQuad.transform.position= new Vector3(secondQuad.transform.position.x + horzExtent ,transform.position.y, transform.position.z);
			}
		}

		if(_manager.GetCountCheckpoint()>0){
			if(texture.Length >= _manager.GetCountCheckpoint()){
				int i = _manager.GetCountCheckpoint() - 1;
				renderer.material.mainTexture = texture[i];
				secondQuad.renderer.material.mainTexture = texture[i];
				thirdQuad.renderer.material.mainTexture = texture[i];
			}
		}else{
			renderer.material.mainTexture = originTexture;
			secondQuad.renderer.material.mainTexture = originTexture;
			thirdQuad.renderer.material.mainTexture = originTexture;
		}
	}

	public void moveBackgroundToLastCheckpoint(){
		transform.position = new Vector3(_manager.GetCheckpoint().x, transform.position.y, transform.position.z);
		secondQuad.transform.position = new Vector3 (transform.position.x+horzExtent,secondQuad.transform.position.y,secondQuad.transform.position.z);
		thirdQuad.transform.position = new Vector3 (secondQuad.transform.position.x+horzExtent,thirdQuad.transform.position.y,thirdQuad.transform.position.z);
	}

}
