using UnityEngine;
using System.Collections;

public class ParallaxBackgroundsSky : MonoBehaviour {
	public float speed = 0.1f;
	public Texture[] texture;

	private GameManager _manager;
	private Texture originTexture ;
	private float vertExtent;		// The size of vertical of the screen.
//	private float horzExtent;		// The size of horizontal of the screen.


	// Use this for initialization
	void Start () {
		_manager = Camera.main.GetComponent<GameManager> ();
		originTexture = renderer.material.mainTexture;

		float minY = Mathf.Abs(Camera.main.GetComponent<CameraFollow>().minY);
		float maxY = Mathf.Abs(Camera.main.GetComponent<CameraFollow>().maxY);

		vertExtent = Camera.main.camera.orthographicSize*2;  
//		horzExtent = vertExtent * Camera.main.pixelWidth / Camera.main.pixelHeight;
//		transform.localScale = new Vector3 (horzExtent, vertExtent  + minY + maxY, 1);
		transform.localScale = new Vector3 (transform.localScale.x, 1, (vertExtent  + minY + maxY)/10);
//		renderer.material.mainTextureScale = new Vector2(renderer.material.mainTextureScale.x, (vertExtent  + minY + maxY)/10);
	}
	
	// Update is called once per frame
	void Update () {
//		transform.position = new Vector3(Camera.main.transform.position.x,transform.position.y,transform.position.z);

		renderer.material.mainTextureOffset = new Vector2 (Time.time*speed,0);
		if(_manager.GetCountCheckpoint()>0){
			if(texture.Length >= _manager.GetCountCheckpoint()){
				int i = _manager.GetCountCheckpoint() - 1;
				renderer.material.mainTexture = texture[i];
			}
		}else{
			renderer.material.mainTexture = originTexture;
		}
	}
}
