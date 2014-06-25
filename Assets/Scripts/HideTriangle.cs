using UnityEngine;
using System.Collections;

public class HideTriangle : MonoBehaviour {

	private Vector3 posTemp;
	// Use this for initialization
	void Start () {
		posTemp = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float cameraPositionX = Camera.main.transform.position.x;
		if(transform.position.x < cameraPositionX)
		{
			if(cameraPositionX  - transform.position.x > 50)
			{
				transform.position += new Vector3(0.0f,-10.0f,0.0f);
			}
		}
		else
		{
			transform.position = posTemp;
		}
	}
}
