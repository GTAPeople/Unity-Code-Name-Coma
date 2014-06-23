﻿using UnityEngine;
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
	private float vertExtent;		// The size of vertical of the screen.
	private float horzExtent;		// The size of horizontal of the screen.
	
	private Transform player;		// Reference to the playerTran's transform.
	private float targetDeadStartX;	// By default for deadStart position x

	// Use this for initialization
	void Start () {
		vertExtent = Camera.main.camera.orthographicSize;  
		horzExtent = vertExtent * Camera.main.pixelWidth / Camera.main.pixelHeight;
		minX = horzExtent + deadStart.transform.position.x + (deadStart.GetComponent<BoxCollider2D>().size.x/2);
		maxX = deadEnd.transform.position.x - deadEnd.GetComponent<BoxCollider2D>().size.x/2 - horzExtent;
//		Debug.Log (Screen.width);
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
	
	// This function is called every fixed framerate frame
	void FixedUpdate ()
	{
		if(GameObject.FindGameObjectWithTag("Player")){
			player = GameObject.FindGameObjectWithTag("Player").transform;
		}
		if(player!=null){		
			TrackPlayer();
			float abyss = minY-vertExtent;
			if(player.position.y < abyss){
				PlayerPrefsX.SetBool("PlayerStatus", false);

				GameObject[] lights = GameObject.FindGameObjectsWithTag ("Luz");
				Debug.Log("tamlig: " + lights.Length);
				for(int i = 0; i < lights.Length; i++)
				{
					Destroy(lights[i]);
				}

				Destroy(player.gameObject);
			}
		}
	}

	void TrackPlayer ()
	{
		// By default the target x and y coordinates of the camera are it's current x and y coordinates.
		float targetX = transform.position.x;
		float targetY = transform.position.y;

		targetDeadStartX = deadStart.transform.position.x;
		
		// If the player has moved beyond the x margin...
		if(CheckXMargin()){
			// To make the camera move right, not left.
			if(player.position.x > transform.position.x){
				// ... the target x coordinate should be a Lerp between the camera's current x position and the player's current x position.
				targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.deltaTime);
			}
			// To make the camera move left when there is deadStart in the screen or the deadStart is in the left of the screen
			if((targetDeadStartX + deadStart.GetComponent<BoxCollider2D>().size.x) <= (transform.position.x - horzExtent)){
				targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.deltaTime);
			}
		}

		// If the player has moved beyond the y margin...
		if(CheckYMargin()){
			// ... the target y coordinate should be a Lerp between the camera's current y position and the player's current y position.
			targetY = Mathf.Lerp(transform.position.y, player.position.y, ySmooth * Time.deltaTime);
		}

		// To move the deadStart to right.
		if(player.position.x > transform.position.x){
			targetDeadStartX = Mathf.Lerp(deadStart.transform.position.x,transform.position.x-horzExtent - (deadStart.GetComponent<BoxCollider2D>().size.x/2),xSmooth * Time.deltaTime);
		}


		// Move deadStart while player move
//		Debug.Log (targetDeadStartX);
		deadStart.transform.position = new Vector3(targetDeadStartX,deadStart.transform.position.y,deadStart.transform.position.z);

		// The target x and y coordinates should not be larger than the maximum or smaller than the minimum.
		targetX = Mathf.Clamp(targetX, minX, maxX);
		targetY = Mathf.Clamp(targetY, minY, maxY);
		
		// Set the camera's position to the target position with the same z component.
		transform.position = new Vector3(targetX, targetY, transform.position.z);
	}

	// A public method for GameManager script only. Move the camera to the last checkpoint by deadStart after player die and during Death Scene
	public void moveToLastCheckpoint(){
		transform.position = new Vector3(deadStart.transform.position.x + ((deadStart.GetComponent<BoxCollider2D>().size.x)/2) + horzExtent, transform.position.y, transform.position.z);
	}
}
