using UnityEngine;
using System.Collections;

public class ParallaxScrollingBackgrounds : MonoBehaviour {
	public float speed = 0.4f;
	public Texture texture;
	public int check = 0;

	private Texture originTexture ;
	private float vertExtent;		// The size of vertical of the screen.
	private float horzExtent;		// The size of horizontal of the screen.


	// Use this for initialization
	void Start () {
		originTexture = renderer.material.mainTexture;
		vertExtent = Camera.main.camera.orthographicSize*2;  
		horzExtent = vertExtent * Camera.main.pixelWidth / Camera.main.pixelHeight;
		transform.localScale = new Vector3 (horzExtent, vertExtent, 1);
	}
	
	// Update is called once per frame
	void Update () {
		renderer.material.mainTextureOffset = new Vector2 (Time.time*speed,0);
		if(check>0){
			renderer.material.mainTexture = texture;
		}else{
			renderer.material.mainTexture = originTexture;
		}
	}
}
