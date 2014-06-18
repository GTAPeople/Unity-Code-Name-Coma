using UnityEngine;
using System.Collections;

public class CheckPoint1 : MonoBehaviour {

	//public GameObject Player;
	//public GameObject Piso6;
	public GameObject _spawnPoint;

	//public bool ActCHP = false ;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider otro)
	{
		if(otro.CompareTag ("Player"))
		{
			//if (ActCHP == false)
			//	ActCHP = true;
			_spawnPoint.transform.position = transform.position;
			PlayerPrefs.SetFloat("spawnPointX",_spawnPoint.transform.position.x);
			PlayerPrefs.SetFloat("spawnPointY",_spawnPoint.transform.position.y);
			PlayerPrefs.SetFloat("spawnPointZ",_spawnPoint.transform.position.z);

			collider.enabled = false;
		}
	}
}
