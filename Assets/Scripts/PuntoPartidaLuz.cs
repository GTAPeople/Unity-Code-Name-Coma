using UnityEngine;
using System.Collections;

public class PuntoPartidaLuz : MonoBehaviour {

	public GameObject PreviousLightStart;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		/*bool status = PlayerPrefsX.GetBool("PlayerStatus");
		if(!status)
		{
			Destroy(gameObject);
		}   */                     

	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player")){
			Debug.Log("x: " + PreviousLightStart.transform.position.x);
			PlayerPrefsX.SetVector3("OldLevelLight", new Vector3(PreviousLightStart.transform.position.x, -1.190162f, 0.0f));
		}

	}
}
