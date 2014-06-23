using UnityEngine;
using System.Collections;

public class RayCast2d : MonoBehaviour {

	public bool flag = false;

	public bool front;
	public bool back;
	public GameObject LuzDelantera;
	public GameObject LuzTrasera;

	public GameObject lightMesh;
	private Mesh mesh;

	private Vector3[] vertices;
	private Vector2[] uvs;
	private int[] triangles;
	private int[] triangles2;
	private int RaysToShoot = 8;
	private float distance = 2;

	private float xoffset = 3.0f;
	private float yoffset = -3.0f;
	private float factor = 0.1f;

	public Transform SightStart;

	private System.Collections.Generic.List<Vector3> myListlight = new System.Collections.Generic.List<Vector3>();
	private System.Collections.Generic.List<Vector3> myListlight2 = new System.Collections.Generic.List<Vector3>();
	private System.Collections.Generic.List<Vector2> myList = new System.Collections.Generic.List<Vector2>();
	private System.Collections.Generic.List<Vector2> myList2 = new System.Collections.Generic.List<Vector2>();

	public GameObject polygon;
	private PolygonCollider2D _polygonCollider;

	private int directionX = 1;
	private int directionY = -1;

	private float initialAngle = -2 * Mathf.PI/3;
	private float lastAngle = -4 * Mathf.PI/3;

	private LineRenderer lineRenderer;
	private GameObject LuzDelantera1;
	private GameObject LuzTrasera1;

	// Use this for initialization
	void Start () {
		if (front) 
		{
			 LuzDelantera1 = (GameObject)Instantiate(LuzDelantera, transform.position, Quaternion.identity);
		}
		if (back) 
		{
			 LuzTrasera1 = (GameObject)Instantiate(LuzTrasera, transform.position, Quaternion.identity);
		}

		lightMesh.transform.position = new Vector3(0.0f,0.0f, lightMesh.transform.position.z);
		mesh = lightMesh.GetComponent<MeshFilter>().mesh;
		vertices = new Vector3[RaysToShoot + 1];
		uvs = new Vector2[RaysToShoot + 1];
		triangles = new int[3 * (vertices.Length - 1)];

		polygon.transform.position = new Vector3(0.0f,0.0f, polygon.transform.position.z);
		_polygonCollider = polygon.GetComponent<PolygonCollider2D>();

		lineRenderer = GetComponent<LineRenderer>();
		lineRenderer.SetWidth(xoffset * factor,xoffset * factor);
	}
	
	// Update is called once per frame
	void Update () {

		vertices[0] = SightStart.position;
		uvs[0] = new Vector2(vertices[0].x,vertices[0].y);
		float angle = initialAngle;
		float angleoffset = (Mathf.Abs(initialAngle - lastAngle)) / RaysToShoot;

		for (int i = 1; i < RaysToShoot + 1; i++)
		{
			float x = Mathf.Sin(angle);
			float y = Mathf.Cos(angle);
			angle -= angleoffset;

			Vector3 dir = new Vector3(x,y,0);
			Vector3 endPoint = SightStart.position + dir * distance;

			RaycastHit2D hit = Physics2D.Linecast(SightStart.position, endPoint, 1 << LayerMask.NameToLayer("mapa"));
			if (hit.point != new Vector2(0,0)) 
			{	
				vertices[i] = new Vector3(hit.point.x, hit.point.y, 1);
				myListlight.Add(new Vector3(hit.point.x, hit.point.y, 1));
				myListlight2.Add(new Vector3(hit.point.x + xoffset * factor, hit.point.y + yoffset * factor, 1));
				myList.Add(new Vector2(hit.point.x, hit.point.y));
				myList2.Add(new Vector2(hit.point.x + xoffset * factor, hit.point.y + yoffset * factor));
			}
			else
			{
				vertices[i] = endPoint;
				vertices[i].z = 1;
			}
			uvs[i] = new Vector2(vertices[i].x,vertices[i].y);
			triangles[(i - 1) * 3] = 0;
			triangles[(i - 1) * 3 + 1] = i; 
			triangles[(i - 1) * 3 + 2] = i + 1;
		}
		triangles[triangles.Length - 1] = 1;

		lineRenderer.SetVertexCount(myList.Count);
		//mesh.vertices = vertices;
		//mesh.triangles = triangles;
		//mesh.uv = uvs;

		Vector3[] pathLigth = new Vector3[myList.Count * 2];
		Vector2[] path = new Vector2[myList.Count * 2];
		for(int i = 0; i < myList.Count; i++)
		{
			path[i] = myList[i];
			pathLigth[i] = myListlight[i];
			lineRenderer.SetPosition(i,pathLigth[i] + new Vector3((xoffset * factor)/2, (yoffset * factor)/2,0));

		}

		if(front)
		{
			LuzDelantera1.transform.position = pathLigth[myList.Count - 1] + new Vector3((xoffset * factor)/2, (yoffset * factor)/2,0);
		}
		if(back)
		{
			LuzTrasera1.transform.position = pathLigth[0] + new Vector3((xoffset * factor)/2, (yoffset * factor)/2,0);
		}

		for(int i = 0; i < myList2.Count; i++)
		{
			path[i + myList2.Count] = myList2[myList2.Count - i - 1];
			pathLigth[i + myList2.Count] = myListlight2[myList2.Count - i - 1];
		}

		//triangles2 = new int[(myList.Count -1) * 6];
		/*
		for(int i = 0; i < path.Length / 2 -1;i++)
		{
			triangles2[i * 6] = i;
			triangles2[i * 6 + 1] = path.Length - i - 1;
			triangles2[i * 6 + 2] = path.Length - i - 2;

			triangles2[i * 6 + 3] = i;
			triangles2[i * 6 + 4] = i + 1;
			triangles2[i * 6 + 5] = path.Length - i - 2;
		}*/

		_polygonCollider.SetPath(0,path);
		myList.Clear();
		myList2.Clear();
		myListlight.Clear();
		myListlight2.Clear();

	}

	public void modificarAngulos(int sentido, float grados)
	{
		initialAngle += sentido * grados;
		lastAngle += sentido * grados;
	}

	void OnDestroy() {
		Destroy(LuzDelantera1);
		Destroy(LuzTrasera1);
	}
}
