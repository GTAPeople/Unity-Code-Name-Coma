using UnityEngine;
using System.Collections;

public class ParallaxScrollingBG : MonoBehaviour {
	public bool FollowCamera;
	public int offset = 10;
	private float X;
	private GameObject _currentPlayer;
	private GameObject _respawn;
	private GameManager _game;

	// Use this for initialization
	void Start () {
		_game = Camera.main.GetComponent<GameManager>();
		if(GameObject.FindGameObjectWithTag("Respawn")){
			_respawn = GameObject.FindGameObjectWithTag("Respawn");
			X = _respawn.transform.position.x;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(GameObject.FindGameObjectWithTag("Player")){
			_currentPlayer = GameObject.FindGameObjectWithTag("Player");
		}
		if(_currentPlayer){
			if(offset!=0){
				if(FollowCamera){
					renderer.material.mainTextureOffset = new Vector2((_currentPlayer.transform.position.x - X)/offset, 0);
				} else {
					renderer.material.mainTextureOffset = new Vector2((X - _currentPlayer.transform.position.x)/offset, 0);
				}
				_game.SetCheckBG(false);
			}
		}else{
			if(_game.GetCheckBG()){
				if(offset!=0){
					if(FollowCamera){
						renderer.material.mainTextureOffset = new Vector2((_game.GetCheckpoint().x - X)/offset, 0);
					} else {
						renderer.material.mainTextureOffset = new Vector2((X - _game.GetCheckpoint().x)/offset, 0);
					}
				}
			}
		}
	}
}
