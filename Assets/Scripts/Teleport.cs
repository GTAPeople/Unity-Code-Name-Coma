using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {
	public GameObject _player;

	public void SpawnPlayer(){
		if(!GameObject.FindGameObjectWithTag("Player")){
			Instantiate (_player, new Vector3(transform.position.x,transform.position.y + ((_player.GetComponent<BoxCollider2D>().size.y/2+_player.GetComponent<CircleCollider2D>().radius)*_player.transform.localScale.y),transform.position.z), Quaternion.identity);
			PlayerPrefsX.SetBool("PlayerStatus", true);
		}
	}
}
