using UnityEngine;
using System.Collections;

[RequireComponent (typeof(BoxCollider))]
public class BoxGizmos : MonoBehaviour {

	public Color _gizmoColor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDrawGizmos(){
		Gizmos.color = _gizmoColor;
		Gizmos.DrawCube(transform.position + GetComponent<BoxCollider>().center,GetComponent<BoxCollider>().size);
	}
}
