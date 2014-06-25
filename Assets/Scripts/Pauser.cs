using UnityEngine;
using System.Collections;

public class Pauser : MonoBehaviour {
//	public GUISkin _pauseSkin;
	public GUISkin _SeguirJugando;
	public GUISkin _SalirMenu;

	private Rect _windowRect;
	private bool _paused = false, waited = true;

	// Use this for initialization
	void Start () {
//		_windowRect = new Rect(Screen.width / 2 - 100, Screen.height / 2 -100,200,200);
		float width1 = Screen.width/2;
		float height1 = Screen.height/2;
		_windowRect = new Rect((Screen.width-width1)/2,(Screen.height*.50f)-height1/2, width1,height1);
	}
	
	// Update is called once per frame
	void Update () {
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
		{
			Time.timeScale = 0; 
			PlayerPrefsX.SetBool("Pause", true);
		}
		else
		{
			Time.timeScale = 1;
			PlayerPrefsX.SetBool("Pause", false);
		}
	}

	private void OnGUI (){
		if (_paused)
			_windowRect = GUI.Window(0,_windowRect,windowFunc, "VAS A PASARLA O EN OTRO RATO ?");
	}
	
	private void windowFunc(int id){
		//GUILayout.BeginHorizontal(); // Para que salgan los botones en forma horizontal debe iniciar y terminar
		float width2 = Screen.width/4;
		float height2 = Screen.height/8;

		GUI.skin = _SeguirJugando;
		Rect rectBotonSeguirJugando =  new Rect((Screen.width-width2)/6,(Screen.height*.12f)-height2/2, width2,height2);
		if(GUI.Button(rectBotonSeguirJugando, "")){
			_paused = false;
		}
		
		GUI.skin = _SalirMenu;
		Rect rectBotonSalirMenu =  new Rect((Screen.width-width2)/6,(Screen.height*.35f)-height2/2, width2,height2);
		//		if (GUILayout.Button ("Salir al Menu Principal")){
		if(GUI.Button(rectBotonSalirMenu, "")){
			Application.LoadLevel("GameMenu");
		}
		//GUILayout.EndHorizontal();
	}
	
	private void waiting(){
		waited = true;
	}
}
