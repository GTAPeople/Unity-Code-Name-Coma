using UnityEngine;
using System.Collections;

public class Continue : MonoBehaviour {

	public GUISkin _textureChkPoint1;
	public GUISkin _textureRegresar1;
	//public GUITexture _textureChkPoint1;
	public Texture2D _imagen;

	private GameObject _checkPoint1;
	// Use this for initialization
	void Start () {

//		_checkPoint1 = GameObject.FindGameObjectWithTag("CheckPoint1");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI (){
		GUI.skin = _textureChkPoint1;
		Rect rectBotonCkeckPoint1 = new Rect(350,50,200,100);
		//if (GUI.Button(rectBotonCkeckPoint1, _imagen)){
		if (GUI.Button(rectBotonCkeckPoint1,"")){
			PlayerPrefs.SetFloat("spawnPointX",29.30195f);
			PlayerPrefs.SetFloat("spawnPointY",0.8594298f);
			PlayerPrefs.SetFloat("spawnPointZ",0.01334476f);
			Application.LoadLevel("Escena1");
		}

		GUI.skin = _textureRegresar1;
		Rect rectBotonRegresar = new Rect (350,400,200,100);
		if (GUI.Button (rectBotonRegresar,"VOLVER AL MENU PRINCIPAL")){
			Application.LoadLevel("Menu");
		}
	}
}
