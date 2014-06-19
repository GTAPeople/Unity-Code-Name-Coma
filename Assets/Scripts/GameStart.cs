using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour {
	private float vertExtent;		// The size of vertical of the screen.
	private float horzExtent;		// The size of horizontal of the screen.

	// Use this for initialization
	void Start () {
		vertExtent = Camera.main.camera.orthographicSize*2;  
		horzExtent = vertExtent * Camera.main.pixelWidth / Camera.main.pixelHeight;
		transform.localScale = new Vector3 (horzExtent/10, 1, vertExtent/10);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKey){
			Application.LoadLevel("GameMenu");
		}
	}
}
