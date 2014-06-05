using UnityEngine;
using System.Collections;

public class ScrollingBackground : MonoBehaviour {
	public float speed = 0.4f;
	private float vertExtent;		// The size of vertical of the screen.
	private float horzExtent;		// The size of horizontal of the screen.
	public GameObject secondQuad;
	public GameObject thirdQuad;
	private GameObject _currentPlayer;

	// Use this for initialization
	void Start () {
		float minY = Mathf.Abs(Camera.main.GetComponent<CameraFollow>().minY);
		float maxY = Mathf.Abs(Camera.main.GetComponent<CameraFollow>().maxY);
		vertExtent = Camera.main.camera.orthographicSize*2;  
		horzExtent = vertExtent * Camera.main.pixelWidth / Camera.main.pixelHeight;
		transform.localScale = new Vector3 (horzExtent, vertExtent + minY + maxY, 1);
		secondQuad.transform.localScale = new Vector3 (horzExtent, vertExtent + minY + maxY, 1);
		thirdQuad.transform.localScale = new Vector3 (horzExtent, vertExtent + minY + maxY, 1);
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
				Debug.Log("Got first");
				transform.position= new Vector3(thirdQuad.transform.position.x + horzExtent ,transform.position.y, transform.position.z);
			}
			if(_currentPlayer.transform.position.x > (secondQuad.transform.position.x+(horzExtent*1.5))){
				Debug.Log("Got second");
				secondQuad.transform.position= new Vector3(transform.position.x + horzExtent ,transform.position.y, transform.position.z);
			}
			if(_currentPlayer.transform.position.x > (thirdQuad.transform.position.x+(horzExtent*1.5))){
				Debug.Log("Got third");
				thirdQuad.transform.position= new Vector3(secondQuad.transform.position.x + horzExtent ,transform.position.y, transform.position.z);
			}
		}
	}
}
