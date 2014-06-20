using UnityEngine;
using System.Collections;

public class ScreenLevel : MonoBehaviour {
	public GUISkin _textureLock;
	public GUISkin[] _textureUnlock;
	public GUISkin _textureRegresar;

	private float vertExtent;		// The size of vertical of the screen.
	private float horzExtent;		// The size of horizontal of the screen.

	private bool[] _checkBool;
	private Vector3[] _checkVector;
	private int _totalLevel = 10;

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

		_checkBool = PlayerPrefsX.GetBoolArray ("LevelBool",false,_totalLevel);
		_checkVector = PlayerPrefsX.GetVector3Array ("CheckVector",new Vector3(0,0,0),_totalLevel);
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
		if(_checkBool[0]==false){
			GUI.skin = _textureLock;
		}else{
			if(_textureUnlock!=null){
				if((_textureUnlock.Length!=0)&&(_textureUnlock.Length<=_totalLevel)&&(_textureUnlock.Length>=1)){
					GUI.skin = _textureUnlock[0];
				}
			}else{
				GUI.skin = null;
			}
		}
		Rect rectBotonCkeckPoint01 = new Rect((Screen.width*.25f)-width/2,(Screen.height*.2f)-height/2,width,height);
		if (GUI.Button(rectBotonCkeckPoint01,"")){
			if(_checkBool[0]==true){
				PlayerPrefsX.SetVector3("CheckSpawn",_checkVector[0]);
				PlayerPrefs.SetInt("CountCheck",1);
				Application.LoadLevel("LevelScene");
			}
		}
		if(_checkBool[1]==false){
			GUI.skin = _textureLock;
		}else{
			if(_textureUnlock!=null){
				if((_textureUnlock.Length!=0)&&(_textureUnlock.Length<=_totalLevel)&&(_textureUnlock.Length>=2)){
					GUI.skin = _textureUnlock[1];
				}
			}else{
				GUI.skin = null;
			}
		}
		Rect rectBotonCkeckPoint02 = new Rect((Screen.width-width)/2,(Screen.height*.2f)-height/2,width,height);
		if (GUI.Button(rectBotonCkeckPoint02,"")){
			if(_checkBool[1]==true){
				PlayerPrefsX.SetVector3("CheckSpawn",_checkVector[1]);
				PlayerPrefs.SetInt("CountCheck",2);
				Application.LoadLevel("LevelScene");
			}
		}
		if(_checkBool[2]==false){
			GUI.skin = _textureLock;
		}else{
			if(_textureUnlock!=null){
				if((_textureUnlock.Length!=0)&&(_textureUnlock.Length<=_totalLevel)&&(_textureUnlock.Length>=3)){
					GUI.skin = _textureUnlock[2];
				}
			}else{
				GUI.skin = null;
			}
		}
		Rect rectBotonCkeckPoint03 = new Rect((Screen.width*.75f)-width/2,(Screen.height*.2f)-height/2,width,height);
		if (GUI.Button(rectBotonCkeckPoint03,"")){
			if(_checkBool[2]==true){
				PlayerPrefsX.SetVector3("CheckSpawn",_checkVector[2]);
				PlayerPrefs.SetInt("CountCheck",3);
				Application.LoadLevel("LevelScene");
			}
		}
		if(_checkBool[3]==false){
			GUI.skin = _textureLock;
		}else{
			if(_textureUnlock!=null){
				if((_textureUnlock.Length!=0)&&(_textureUnlock.Length<=_totalLevel)&&(_textureUnlock.Length>=4)){
					GUI.skin = _textureUnlock[3];
				}
			}else{
				GUI.skin = null;
			}
		}
		Rect rectBotonCkeckPoint04 = new Rect((Screen.width*.25f)-width/2,(Screen.height*.4f)-height/2,width,height);
		if (GUI.Button(rectBotonCkeckPoint04,"")){
			if(_checkBool[3]==true){
				PlayerPrefsX.SetVector3("CheckSpawn",_checkVector[3]);
				PlayerPrefs.SetInt("CountCheck",4);
				Application.LoadLevel("LevelScene");
			}
		}
		if(_checkBool[4]==false){
			GUI.skin = _textureLock;
		}else{
			if(_textureUnlock!=null){
				if((_textureUnlock.Length!=0)&&(_textureUnlock.Length<=_totalLevel)&&(_textureUnlock.Length>=5)){
					GUI.skin = _textureUnlock[4];
				}
			}else{
				GUI.skin = null;
			}
		}
		Rect rectBotonCkeckPoint05 = new Rect((Screen.width-width)/2,(Screen.height*.4f)-height/2,width,height);
		if (GUI.Button(rectBotonCkeckPoint05,"")){
			if(_checkBool[4]==true){
				PlayerPrefsX.SetVector3("CheckSpawn",_checkVector[4]);
				PlayerPrefs.SetInt("CountCheck",5);
				Application.LoadLevel("LevelScene");
			}
		}
		if(_checkBool[5]==false){
			GUI.skin = _textureLock;
		}else{
			if(_textureUnlock!=null){
				if((_textureUnlock.Length!=0)&&(_textureUnlock.Length<=_totalLevel)&&(_textureUnlock.Length>=6)){
					GUI.skin = _textureUnlock[5];
				}
			}else{
				GUI.skin = null;
			}
		}
		Rect rectBotonCkeckPoint06 = new Rect((Screen.width*.75f)-width/2,(Screen.height*.4f)-height/2,width,height);
		if (GUI.Button(rectBotonCkeckPoint06,"")){
			if(_checkBool[5]==true){
				PlayerPrefsX.SetVector3("CheckSpawn",_checkVector[5]);
				PlayerPrefs.SetInt("CountCheck",6);
				Application.LoadLevel("LevelScene");
			}
		}
		if(_checkBool[6]==false){
			GUI.skin = _textureLock;
		}else{
			if(_textureUnlock!=null){
				if((_textureUnlock.Length!=0)&&(_textureUnlock.Length<=_totalLevel)&&(_textureUnlock.Length>=7)){
					GUI.skin = _textureUnlock[6];
				}
			}else{
				GUI.skin = null;
			}
		}
		Rect rectBotonCkeckPoint07 = new Rect((Screen.width*.25f)-width/2,(Screen.height*.6f)-height/2,width,height);
		if (GUI.Button(rectBotonCkeckPoint07,"")){
			if(_checkBool[6]==true){
				PlayerPrefsX.SetVector3("CheckSpawn",_checkVector[6]);
				PlayerPrefs.SetInt("CountCheck",7);
				Application.LoadLevel("LevelScene");
			}
		}
		if(_checkBool[7]==false){
			GUI.skin = _textureLock;
		}else{
			if(_textureUnlock!=null){
				if((_textureUnlock.Length!=0)&&(_textureUnlock.Length<=_totalLevel)&&(_textureUnlock.Length>=8)){
					GUI.skin = _textureUnlock[7];
				}
			}else{
				GUI.skin = null;
			}
		}
		Rect rectBotonCkeckPoint08 = new Rect((Screen.width-width)/2,(Screen.height*.6f)-height/2,width,height);
		if (GUI.Button(rectBotonCkeckPoint08,"")){
			if(_checkBool[7]==true){
				PlayerPrefsX.SetVector3("CheckSpawn",_checkVector[7]);
				PlayerPrefs.SetInt("CountCheck",8);
				Application.LoadLevel("LevelScene");
			}
		}
		if(_checkBool[8]==false){
			GUI.skin = _textureLock;
		}else{
			if(_textureUnlock!=null){
				if((_textureUnlock.Length!=0)&&(_textureUnlock.Length<=_totalLevel)&&(_textureUnlock.Length>=9)){
					GUI.skin = _textureUnlock[8];
				}
			}else{
				GUI.skin = null;
			}
		}
		Rect rectBotonCkeckPoint09 = new Rect((Screen.width*.75f)-width/2,(Screen.height*.6f)-height/2,width,height);
		if (GUI.Button(rectBotonCkeckPoint09,"")){
			if(_checkBool[8]==true){
				PlayerPrefsX.SetVector3("CheckSpawn",_checkVector[8]);
				PlayerPrefs.SetInt("CountCheck",9);
				Application.LoadLevel("LevelScene");
			}
		}
		if(_checkBool[9]==false){
			GUI.skin = _textureLock;
		}else{
			if(_textureUnlock!=null){
				if((_textureUnlock.Length!=0)&&(_textureUnlock.Length<=_totalLevel)&&(_textureUnlock.Length>=10)){
					GUI.skin = _textureUnlock[9];
				}
			}else{
				GUI.skin = null;
			}
		}
		Rect rectBotonCkeckPoint10 = new Rect((Screen.width*.25f)-width/2,(Screen.height*.8f)-height/2,width,height);
		if (GUI.Button(rectBotonCkeckPoint10,"")){
			if(_checkBool[9]==true){
				PlayerPrefsX.SetVector3("CheckSpawn",_checkVector[9]);
				PlayerPrefs.SetInt("CountCheck",10);
				Application.LoadLevel("LevelScene");
			}
		}

		GUI.skin = _textureRegresar;
		Rect rectBotonRegresar = new Rect ((Screen.width-width)/2,(Screen.height*.8f)-height/2,width*2,height);
		if (GUI.Button (rectBotonRegresar,"VOLVER AL MENU PRINCIPAL")){
			Application.LoadLevel("GameMenu");
		}
	}
}
