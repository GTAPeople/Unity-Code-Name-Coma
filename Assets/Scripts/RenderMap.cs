using UnityEngine;
using System.Collections;

public class RenderMap : MonoBehaviour {

	public bool Render = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Render)
		{
			Renderer[] AllChildren = GetComponentsInChildren<Renderer>();
			for(int i = 0; i < AllChildren.Length; i++)
			{
				AllChildren[i].enabled = true;
			}
		}
		else
		{
			Renderer[] AllChildren = GetComponentsInChildren<Renderer>();
			for(int i = 0; i < AllChildren.Length; i++)
			{
				AllChildren[i].enabled = false;
			}
		}
	}
}
