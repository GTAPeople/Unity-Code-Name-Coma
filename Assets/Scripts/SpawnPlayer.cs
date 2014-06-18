using UnityEngine;
using System.Collections;

public class SpawnPlayer : MonoBehaviour {
	private GameObject player;


	// Use this for initialization
	void Start () {
		float x = PlayerPrefs.GetFloat ("spawnPointX",0);
		float y = PlayerPrefs.GetFloat ("spawnPointY",0);
		float z = PlayerPrefs.GetFloat ("spawnPointZ",0);
		if (x != 0 || y != 0 || z !=0)
			transform.position = new Vector3(x,y,z);
		player = GameObject.FindGameObjectWithTag ("Player");
		player.transform.position = transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
