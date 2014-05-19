using UnityEngine;
using System.Collections;

public class DestroyPlayer : MonoBehaviour {
	public GameObject _deathAnimation;

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag =="Player"){
			Destroy(other.gameObject);
			Instantiate (_deathAnimation, other.transform.position, Quaternion.identity);
		}
	}
}
