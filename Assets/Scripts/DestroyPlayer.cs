using UnityEngine;
using System.Collections;

public class DestroyPlayer : MonoBehaviour {
	public GameObject _deathAnimation;

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag =="Player"){
			Destroy(other.gameObject);
			PlayerPrefsX.SetBool("PlayerStatus", false);

			GameObject[] lights = GameObject.FindGameObjectsWithTag ("Luz");
			for(int i = 0; i < lights.Length; i++)
			{
				Destroy(lights[i]);
			}

			Instantiate (_deathAnimation, other.transform.position, Quaternion.identity);

		}
	}
}
