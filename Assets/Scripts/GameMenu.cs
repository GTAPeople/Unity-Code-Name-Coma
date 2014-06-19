using UnityEngine;
using System.Collections;

public class GameMenu : MonoBehaviour {
	public GUISkin _skinNuevo;
	public GUISkin _skinContinuar;
	public GUISkin _skinSalir;

	private float vertExtent;		// The size of vertical of the screen.
	private float horzExtent;		// The size of horizontal of the screen.

	// Use this for initialization
	void Start () {
		vertExtent = Camera.main.camera.orthographicSize*2;  
		horzExtent = vertExtent * Camera.main.pixelWidth / Camera.main.pixelHeight;
		transform.localScale = new Vector3 (horzExtent/10, 1, vertExtent/10);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		float width = 130;
		float height = 30;
		GUI.skin = _skinNuevo;
		Rect rectBotonNewGame =  new Rect((Screen.width-width)/2,(Screen.height*.55f)-height/2, width,height);
		GUI.skin = _skinContinuar;
		Rect rectBotonContinuar = new Rect((Screen.width-width)/2,(Screen.height*.60f)-height/2, width,height);
		GUI.skin = _skinSalir;
		Rect rectBotonSalir = new Rect ((Screen.width-width)/2, (Screen.height*.65f)-height/2, width,height);

		if (GUI.Button (rectBotonNewGame, "NUEVO JUEGO")){
			PlayerPrefsX.SetVector3("checkpoint", new Vector3(0,0,0));
			Application.LoadLevel("LevelScene");
		}
		if (GUI.Button(rectBotonContinuar, "CONTINUAR")){
			//Application.LoadLevel("Game");
			Application.LoadLevel("CheckLevel");			
		}
		if (GUI.Button (rectBotonSalir, "SALIR DEL JUEGO")) {
			Application.Quit();
		}
	}
}
