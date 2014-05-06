using UnityEngine;
using System.Collections;

public class MoveObject2DCircle : MonoBehaviour {
	public float speed = 3.0f;
	public float radius = 1.0f;
	public float speedTimeDelay = 0.0f;

	private float posXOrigin;
	private float posYOrigin;

	// Use this for initialization
	void Start () {
		posXOrigin = transform.position.x;
		posYOrigin = transform.position.y;
	}

	// Update is called once per frame
	void Update () {
		float xPos = Mathf.Sin(speed*(Time.time-speedTimeDelay)) * radius + posXOrigin;		
		float yPos = Mathf.Cos(speed*(Time.time-speedTimeDelay)) * radius + posYOrigin;
		transform.position = new Vector3 (xPos,yPos,transform.position.z);
	}
}
