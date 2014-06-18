using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {
	public GUISkin _skinNuevo;


	// Use this for initialization
	void Start () {
	
	}

	public Texture _textura;

	// Update is called once per frame
	void OnGUI () {

		GUI.skin = _skinNuevo;

		//Rect rectLabel = new Rect(100,100,170,30);
		//GUI.Label (rectLabel,"M E N U   P R I N C I P A L");

		Rect rectBotonNewGame =  new Rect(200,200,130,30);

		//float xn = (Screen.width / 2) - rectBotonNewGame.width / 2;
		//float yn = (Screen.height / 2) - 15;
		
		//rectBotonNewGame.x = xn;
		//rectBotonNewGame.y = yn;

		Rect rectBotonContinuar = new Rect(200,300,130,30);
		//float x = (Screen.width / 2) - rectButton.width / 2;
		//float y = (Screen.height / 2) - 15;

		//rectButton.x = x;
		//rectButton.y = y;

		Rect rectBotonSalir = new Rect (200, 400, 130, 30);



		if (GUI.Button(rectBotonContinuar, "CONTINUAR")){
			//Application.LoadLevel("Escena1");
			Application.LoadLevel("Continuar");

		}

		if (GUI.Button (rectBotonNewGame, "NUEVO JUEGO")){
			PlayerPrefs.SetFloat("spawnPointX",0);
			PlayerPrefs.SetFloat("spawnPointY",0);
			PlayerPrefs.SetFloat("spawnPointZ",0);
			Application.LoadLevel("Escena1");
		}

		if (GUI.Button (rectBotonSalir, "SALIR DEL JUEGO")) {
			Application.Quit();
		}
	
	}
}
