using UnityEngine;
using System.Collections;

public class Reinicio : MonoBehaviour {
	public GameObject player;
	public GameObject _spawnpointini;
//	public GameObject Piso1;
//	public GameObject Piso6;

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
			//if (GetComponent<CheckPoint>().ActCHP == true)
			//{
			//	Invoke("AplicaCheckPoint",1);
			//}
			//else
			//{
				Invoke("Reiniciar",1);
			//}
		}
	}

	void Reiniciar ()
	{
//		float x = PlayerPrefs.GetFloat ("spawnPointX",0);
//		float y = PlayerPrefs.GetFloat ("spawnPointY",0);
//		float z = PlayerPrefs.GetFloat ("spawnPointZ",0);
//		if (x != 0 || y != 0 || z !=0)
		player.transform.position = new Vector3(_spawnpointini.transform.position.x,
			                                    _spawnpointini.transform.position.y,
			                                    _spawnpointini.transform.position.z);
//		player = GameObject.FindGameObjectWithTag ("Player");
//		player.transform.position = transform.position;

//		Player.transform.position = new Vector3(Piso1.transform.position.x,
//		                                        Piso1.transform.position.y+2,
//		                                        Piso1.transform.position.z
//												);
//
	}
//
//	void AplicaCheckPoint()
//	{
//		Player.transform.position = new Vector3(Piso6.transform.position.x,
//			                                    Piso6.transform.position.y+2,
//			                                    Piso6.transform.position.z
//			                                    );
//	}
}
