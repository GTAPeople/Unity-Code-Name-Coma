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
		float menor = 999999999.0f;
		for(int i = 0; i < AllChildren.Length; i++)
		{
			if(AllChildren[i].position.x > mayor)
			{
				mayor = AllChildren[i].position.x;
			}

			if(AllChildren[i].position.x < menor)
			{
				menor = AllChildren[i].position.x;
			}
		}

		float cameraPositionX = Camera.main.transform.position.x;
		if(mayor > cameraPositionX)
		{
			if(mayor - cameraPositionX > 30)
			{
				Destroy(gameObject);
			}
		}
		else
		{
			if(cameraPositionX - mayor > 30)
			{
				Destroy(gameObject);
			}
		}


		/*if(Camera.main.transform.position.x - transform.position.x > 20 )
		{
			Destroy(gameObject);
		}*/
	}
}
