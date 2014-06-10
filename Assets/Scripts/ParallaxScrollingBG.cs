using UnityEngine;
using System.Collections;

public class ParallaxScrollingBG : MonoBehaviour {
	public int offset;
	public bool FollowCamera;
	private float X;

	// Use this for initialization
	void Start () {
		X = Camera.main.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		if(FollowCamera){
//			transform.position = new Vector2((Camera.main.transform.position.x - X)/offset, transform.position.y);
//			renderer.material.mainTextureOffset = new Vector2((Camera.main.transform.position.x - X)/offset, transform.position.y);
		} else {
//			transform.position = new Vector2((X - Cam	era.main.transform.position.x)/offset, transform.position.y);
//			renderer.material.mainTextureOffset = new Vector2((X - Camera.main.transform.position.x)/offset, transform.position.y);
		}
	}
}
