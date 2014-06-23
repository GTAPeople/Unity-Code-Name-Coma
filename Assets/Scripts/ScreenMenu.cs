using UnityEngine;
using System.Collections;

public class ScreenMenu : MonoBehaviour {
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
		float width = Screen.width/4;
		float height = Screen.height/8;
		GUI.skin = _skinNuevo;
		Rect rectBotonNewGame =  new Rect((Screen.width-width)/2,(Screen.height*.25f)-height/2, width,height);
		GUI.skin = _skinContinuar;
		Rect rectBotonContinuar = new Rect((Screen.width-width)/2,(Screen.height*.50f)-height/2, width,height);
		GUI.skin = _skinSalir;
		Rect rectBotonSalir = new Rect ((Screen.width-width)/2, (Screen.height*.75f)-height/2, width,height);

		if (GUI.Button (rectBotonNewGame, "NUEVO JUEGO")){
			PlayerPrefsX.SetVector3("CheckSpawn", Vector3.zero);
			PlayerPrefs.SetInt("CountCheck",0);
			PlayerPrefsX.SetVector3 ("OldLevelLight",new Vector3(-12,1,0));
//			PlayerPrefs.DeleteAll();
			Application.LoadLevel("LevelScene");
//			Application.LoadLevel("Game");
		}
		if (GUI.Button(rectBotonContinuar, "CONTINUAR")){
			Application.LoadLevel("CheckLevel");			
		}
		if (GUI.Button (rectBotonSalir, "SALIR DEL JUEGO")) {
			Application.Quit();
		}
	}
}
