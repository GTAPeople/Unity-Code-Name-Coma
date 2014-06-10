using UnityEngine;
using System.Collections;

public class CrearPoligono : MonoBehaviour {

	private PolygonCollider2D _polygonCollider;
	public System.Collections.Generic.List<Vector2> myList = new System.Collections.Generic.List<Vector2>();

	// Use this for initialization
	void Start () {
		_polygonCollider = this.GetComponent<PolygonCollider2D>();
		setPolygonOfIndex();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setPolygonOfIndex() {
		_polygonCollider.pathCount = 1;
		
		/*for(int i = 0; i < _polygonCollider.pathCount; i++) 
		{
			Vector2[] tempPoints = new Vector2[5];
			for(int j = 0; j < 4; j++) 
			{
				tempPoints[j] = new Vector2(0, j + 1);
			}
			tempPoints[4] = new Vector2(0, 1);
			
			_polygonCollider.SetPath(i,tempPoints);
		}*/


		Vector2[] tempPoints = new Vector2[6];
		tempPoints[0] = new Vector2(-0.3f, -1.0f);
		tempPoints[1] = new Vector2(-0.9f, -1.0f);
		tempPoints[2] = new Vector2(-1.5f, -1.0f);
		tempPoints[3] = new Vector2(-1.5f, -2.0f);
		tempPoints[4] = new Vector2(-0.9f, -2.0f);
		tempPoints[5] = new Vector2(-0.3f, -2.0f);

		myList.Add(tempPoints[0]);
		myList.Add(tempPoints[1]);
		myList.Add(tempPoints[2]);

		Debug.Log(myList.Count);

		_polygonCollider.SetPath(0,tempPoints);
	}
}
