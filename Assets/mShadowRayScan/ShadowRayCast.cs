using UnityEngine;
using System.Collections;

public class ShadowRayCast : MonoBehaviour {

	public GameObject lightmeshholder;

	private int RaysToShoot = 64; //64; 128; 1024; 
	private float distanceRay = 15.0f;
	private Vector3[] vertices;
	private Vector2[] vertices2d;
	private int[] triangles;
	private Mesh mesh;

	// Use this for initialization
	void Start () {
		vertices2d = new Vector2[RaysToShoot];
		mesh = lightmeshholder.GetComponent<MeshFilter>().mesh;

		BuildMesh ();
	}
	
	// Update is called once per frame
	void Update () {

		vertices = mesh.vertices;

		float angle = 0.0f;

		int i;
		for(i = 0; i < RaysToShoot; i++)
		{
			float angleX = Mathf.Sin(angle);
			float angleY = Mathf.Cos(angle);
			
			angle += 2 * Mathf.PI / RaysToShoot;
			Vector3 direction = new Vector3(angleX, 0, angleY);
			
			RaycastHit hit;
			
			if(Physics.Raycast(transform.position, direction, out hit, distanceRay))
			{
				//Debug.Log(i);
				Vector3 temporalVector = lightmeshholder.transform.InverseTransformPoint(hit.point);
				vertices[i] = new Vector3(temporalVector.x, 0.5f, temporalVector.y);
			}
			else
			{
				Vector3 temporalVector = lightmeshholder.transform.
					InverseTransformPoint(lightmeshholder.transform.position + direction);
				vertices[i] = new Vector3(temporalVector.x, 0.5f, temporalVector.y);
			}
		}

		// last vertice is at the player location (center point)
		vertices[i] = lightmeshholder.transform.InverseTransformPoint(transform.position);
		
		mesh.vertices = vertices;
	}

	void BuildMesh ()
	{
		// dont cast if not moved?
		// build prelook-array of hit points/pixels/areas?
		// skip duplicate hit points (compare previous)
		// always same amount of vertices, no need create new mesh?..but need to triangulate or not??

		float angle = 0.0f;

		for(int i = 0; i < RaysToShoot; i++)
		{
			float angleX = Mathf.Sin(angle);
			float angleY = Mathf.Cos(angle);

			angle += 2 * Mathf.PI / RaysToShoot;
			Vector3 direction = new Vector3(angleX, 0, angleY);

			RaycastHit hit;

			if(Physics.Raycast(transform.position, direction, out hit, distanceRay))
			{
				Debug.Log(i);
				Debug.DrawLine (transform.position, hit.point, Color.green);
				Vector3 temporalVector = lightmeshholder.transform.InverseTransformPoint(hit.point);
				vertices2d[i] = new Vector2(temporalVector.x, temporalVector.z);
			}
			else
			{
				Vector3 temporalVector = lightmeshholder.transform.
					InverseTransformPoint(lightmeshholder.transform.position + direction);
				vertices2d[i] = new Vector2(temporalVector.x, temporalVector.z);
			}

		}

		//triangles

		// build mesh
		Vector2[] uvs = new Vector2[vertices2d.Length + 1];
		Vector3[] newVertices = new Vector3[vertices2d.Length + 1];

		for(int i = 0; i < newVertices.Length - 1; i++)
		{
			newVertices[i] = new Vector3(vertices2d[i].x, 0, vertices2d[i].y);
		}

		triangles = new int[newVertices.Length * 3];

		//Debug.Log("t: " + triangles.Length);

		int j = -1;

		for(int i = 0; i < triangles.Length -3; i += 3)
		{
			j++;
			triangles[i] = newVertices.Length - 1;

			if(j >= newVertices.Length)
			{
				triangles[i + 1] = 0;
			}
			else
			{
				triangles[i + 1] = i + 1;
			}
			triangles[i + 2] = i;

			//Debug.Log((i+2) + " " + j);
		}

		j++;

		// central point
		newVertices[newVertices.Length - 1] = new Vector3(0,0,0);
		triangles[triangles.Length - 3] = newVertices.Length - 1;
		triangles[triangles.Length - 2] = 0;
		triangles[triangles.Length - 1] = j - 1;


		Debug.Log("t: " + triangles.Length + " " + newVertices.Length + " " + uvs.Length + " " + vertices2d.Length);

		// Create the mesh
		//var msh : Mesh = new Mesh();
		mesh.vertices = newVertices;
		mesh.triangles = triangles;
		mesh.uv = uvs;

	}
}
