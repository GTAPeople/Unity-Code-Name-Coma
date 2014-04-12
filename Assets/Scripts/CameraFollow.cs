using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public float xMargin = 2f;		// Distance in the x axis the player can move before the camera follows.
	public float yMargin = 2f;		// Distance in the y axis the player can move before the camera follows.
	public float xSmooth = 4f;		// How smoothly the camera catches up with it's target movement in the x axis.
	public float ySmooth = 4f;		// How smoothly the camera catches up with it's target movement in the y axis.
	public GameObject deadStart;	// The GameObject from the start level scene, the camera can have.
	public GameObject deadEnd;		// The GameObject from the end level scene, the camera can have.
	public float maxY;				// The maximum y coordinate the camera can have.
	public float minY;				// The minimum y coordinate the camera can have.

	private float maxX;				// The maximum x coordinate the camera can have.
	private float minX;				// The minimum x coordinate the camera can have.
	private float horzExtent;
	
	private Transform player;		// Reference to the player's transform.

	// Use this for initialization
	void Start () {
		float vertExtent = Camera.main.camera.orthographicSize;  
		horzExtent = vertExtent * Camera.main.pixelWidth / Camera.main.pixelHeight;
		minX = horzExtent + deadStart.transform.position.x + (deadStart.GetComponent<BoxCollider2D>().size.x/2);
		maxX = deadEnd.transform.position.x - deadEnd.GetComponent<BoxCollider2D>().size.x/2 - horzExtent;
//		Debug.Log (Screen.width);
	}	
	
	void Awake ()
	{
		// Setting up the reference.
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	bool CheckXMargin()
	{
		// Returns true if the distance between the camera and the player in the x axis is greater than the x margin.
		return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
	}
	
	
	bool CheckYMargin()
	{
		// Returns true if the distance between the camera and the player in the y axis is greater than the y margin.
		return Mathf.Abs(transform.position.y - player.position.y) > yMargin;
	}
	
	
	void FixedUpdate ()
	{
		TrackPlayer();
	}

	void TrackPlayer ()
	{
		// By default the target x and y coordinates of the camera are it's current x and y coordinates.
		float targetX = transform.position.x;
		float targetY = transform.position.y;

		// By default for deadStart
		float targetDeadStartX = deadStart.transform.position.x;
		
		// If the player has moved beyond the x margin...
		if(CheckXMargin()){
			// To make the camera move right, not left.
			if(player.position.x>transform.position.x){
				// ... the target x coordinate should be a Lerp between the camera's current x position and the player's current x position.
				targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.deltaTime);
				targetDeadStartX = transform.position.x-horzExtent - (deadStart.GetComponent<BoxCollider2D>().size.x/2);
			}
		}
		// If the player has moved beyond the y margin...
		if(CheckYMargin()){
			// ... the target y coordinate should be a Lerp between the camera's current y position and the player's current y position.
			targetY = Mathf.Lerp(transform.position.y, player.position.y, ySmooth * Time.deltaTime);
		}

		// Move deadStart while player move right
//		Debug.Log (targetDeadStartX);
		deadStart.transform.position = new Vector3(targetDeadStartX,deadStart.transform.position.y,deadStart.transform.position.z);

		// The target x and y coordinates should not be larger than the maximum or smaller than the minimum.
		targetX = Mathf.Clamp(targetX, minX, maxX);
		targetY = Mathf.Clamp(targetY, minY, maxY);
		
		// Set the camera's position to the target position with the same z component.
		transform.position = new Vector3(targetX, targetY, transform.position.z);
	}
}
