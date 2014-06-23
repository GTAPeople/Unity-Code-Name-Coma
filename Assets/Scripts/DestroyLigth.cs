using UnityEngine;
using System.Collections;

public class DestroyLigth : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {


		Transform[] AllChildren = GetComponentsInChildren<Transform>();
		float mayor = -999999999.0f;
		for(int i = 0; i < AllChildren.Length; i++)
		{
			if(AllChildren[i].position.x > mayor)
			{
				mayor = AllChildren[i].position.x;
			}
		}

		if(mayor  - Camera.main.transform.position.x > 30)
		{
			Destroy(gameObject);
		}
	}
}
