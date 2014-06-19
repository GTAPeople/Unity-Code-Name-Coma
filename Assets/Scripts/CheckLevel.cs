using UnityEngine;
using System.Collections;

public class CheckLevel : MonoBehaviour {
	public GUISkin _textureLock;
	public GUISkin[] _tetureUnlock;
	public GUISkin _textureRegresar;

	private float vertExtent;		// The size of vertical of the screen.
	private float horzExtent;		// The size of horizontal of the screen.

	private bool[] _next;

	// Use this for initialization
	void Start () {
		vertExtent = Camera.main.camera.orthographicSize*2;  
		horzExtent = vertExtent * Camera.main.pixelWidth / Camera.main.pixelHeight;
		transform.localScale = new Vector3 (horzExtent/10, 1, vertExtent/10);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI (){
		float width = Screen.width/4;
		float height = Screen.height/5;

		var _next = PlayerPrefsX.GetBoolArray ("LevelBool");
//		if (_next != null && _next.Length > 0){
//			for(int i=0; i < _next.Length; i++){
//				if(_next[i]==true){
//					if(_tetureUnlock[i]!=null){
//						GUI.skin = _tetureUnlock[i];
//					}
//				}else{
//					GUI.skin = _textureLock;
//				}
//			}
//		}else{
//			Debug.Log("Please, get checkpoit in game for adding to PlayerPrefsX \t inside the Size.");
//		}

		GUI.skin = _textureLock;
		Rect rectBotonCkeckPoint01 = new Rect((Screen.width*.25f)-width/2,(Screen.height*.2f)-height/2,width,height);
		if (GUI.Button(rectBotonCkeckPoint01,"")){

		}
		Rect rectBotonCkeckPoint02 = new Rect((Screen.width-width)/2,(Screen.height*.2f)-height/2,width,height);
		if (GUI.Button(rectBotonCkeckPoint02,"")){
			
		}
		Rect rectBotonCkeckPoint03 = new Rect((Screen.width*.75f)-width/2,(Screen.height*.2f)-height/2,width,height);
		if (GUI.Button(rectBotonCkeckPoint03,"")){
			
		}
		Rect rectBotonCkeckPoint04 = new Rect((Screen.width*.25f)-width/2,(Screen.height*.4f)-height/2,width,height);
		if (GUI.Button(rectBotonCkeckPoint04,"")){
			
		}
		Rect rectBotonCkeckPoint05 = new Rect((Screen.width-width)/2,(Screen.height*.4f)-height/2,width,height);
		if (GUI.Button(rectBotonCkeckPoint05,"")){
			
		}
		Rect rectBotonCkeckPoint06 = new Rect((Screen.width*.75f)-width/2,(Screen.height*.4f)-height/2,width,height);
		if (GUI.Button(rectBotonCkeckPoint06,"")){
			
		}
		Rect rectBotonCkeckPoint07 = new Rect((Screen.width*.25f)-width/2,(Screen.height*.6f)-height/2,width,height);
		if (GUI.Button(rectBotonCkeckPoint07,"")){
			
		}
		Rect rectBotonCkeckPoint08 = new Rect((Screen.width-width)/2,(Screen.height*.6f)-height/2,width,height);
		if (GUI.Button(rectBotonCkeckPoint08,"")){
			
		}
		Rect rectBotonCkeckPoint09 = new Rect((Screen.width*.75f)-width/2,(Screen.height*.6f)-height/2,width,height);
		if (GUI.Button(rectBotonCkeckPoint09,"")){
			
		}
		Rect rectBotonCkeckPoint10 = new Rect((Screen.width*.25f)-width/2,(Screen.height*.8f)-height/2,width,height);
		if (GUI.Button(rectBotonCkeckPoint10,"")){
			
		}

		GUI.skin = _textureRegresar;
		Rect rectBotonRegresar = new Rect ((Screen.width-width)/2,(Screen.height*.8f)-height/2,width*2,height);
		if (GUI.Button (rectBotonRegresar,"VOLVER AL MENU PRINCIPAL")){
			Application.LoadLevel("GameMenu");
		}
	}
}
