using UnityEngine;
using System.Collections;

[RequireComponent (typeof(BoxCollider2D))]
public class BoxGizmos : MonoBehaviour {

	public Color _gizmoColor;

	private float posX;
	private float posY;
	private Vector3 posV3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDrawGizmos(){
		posX = GetComponent<BoxCollider2D>().size.x;
		posY = GetComponent<BoxCollider2D>().size.y;
		posV3 = new Vector3 (transform.position.x + GetComponent<BoxCollider2D>().center.x, transform.position.y + GetComponent<BoxCollider2D>().center.y, transform.position.z);
		Gizmos.color = _gizmoColor;
		Gizmos.DrawCube(posV3, new Vector3(posX,posY,transform.position.z));
	}
}
