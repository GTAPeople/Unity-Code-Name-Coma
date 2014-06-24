using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
	public GameObject _menuMusic;

	void Awake () {
		GameObject.FindGameObjectWithTag("MusicMenu");
		if (_menuMusic){
			Destroy (_menuMusic);
		}

		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
