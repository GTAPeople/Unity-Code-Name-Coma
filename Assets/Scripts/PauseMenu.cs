using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	public GUISkin _pauseSkin;

	private Rect _windowRect;
	private bool _paused = false, waited = true;

	//public GUITexture _pauseGUI;


	// Use this for initialization
	private void Start () {
		_windowRect = new Rect(Screen.width / 2 - 100, Screen.height / 2 -100,200,200);


		//_pauseGUI.enabled = false;
	
	}

	// Update is called once per frame
	private void Update () {
		if (waited)
		if(Input.GetKey(KeyCode.Escape) || Input.GetKey (KeyCode.P)){
			if(_paused)
				_paused = false;
			else
				_paused = true;
			
			waited = false;
			Invoke("waiting",0.3f); 
		}
		if (_paused)
			Time.timeScale = 0;
		else
			Time.timeScale = 1;
		
	}

	private void OnGUI (){
		if (_paused)
			_windowRect = GUI.Window(0,_windowRect,windowFunc, "Pausa");

		
	}

	private void windowFunc(int id){
		//GUILayout.BeginHorizontal(); // Para que salgan los botones en forma horizontal debe iniciar y terminar
		if(GUILayout.Button("Continuar Jugando")){
			_paused = false;
		}

		if (GUILayout.Button ("Salir al Menu Principal")){
			Application.LoadLevel("Menu");
		}
		//GUILayout.EndHorizontal();
	}

	private void waiting(){
		waited = true;
	}

}
