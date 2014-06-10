using UnityEngine;
using System.Collections;

public class RayCast2d : MonoBehaviour {

	public bool flag = false;

	public GameObject lightMesh;
	private Mesh mesh;

	public GameObject lightMesh2;
	private Mesh mesh2;

	private Vector3[] vertices;
	private Vector2[] uvs;
	private int[] triangles;
	private int[] triangles2;
	private int RaysToShoot = 256;
	private float distance = 5;

	private float xoffset = 10.0f;
	private float yoffset = -10.0f;
	private float factor = 0.1f;

	public Transform SightStart;
	public Transform SightEnd;
	public Transform SightEnd2;
	public Transform SightEnd3;

	public bool spooted = false;
	public bool spooted2 = false;
	public bool spooted3 = false;

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
	// Use this for initialization
	void Start () {
		mesh = lightMesh.GetComponent<MeshFilter>().mesh;
		mesh2 = lightMesh2.GetComponent<MeshFilter>().mesh;
		vertices = new Vector3[RaysToShoot + 1];
		uvs = new Vector2[RaysToShoot + 1];
		triangles = new int[3 * (vertices.Length - 1)];

		_polygonCollider = polygon.GetComponent<PolygonCollider2D>();

		lineRenderer = GetComponent<LineRenderer>();
		lineRenderer.SetWidth(xoffset * factor,xoffset * factor);
		Initialize();
	}
	
	// Update is called once per frame
	void Update () {
		//RayCasting();
		//Behaviors();

		/*vertices[0] = SightStart.position;
		vertices[1] = SightEnd.position;
		vertices[2] = SightEnd2.position;
		vertices[3] = SightEnd3.position;
		vertices[0].z = 1;
		vertices[1].z = 1;
		vertices[2].z = 1;
		vertices[3].z = 1;
		for(int i = 0; i < 3; i++)
		{
			uvs[i] = new Vector2(vertices[i].x,vertices[i].y);
		}
		
		triangles[0] = 0;
		triangles[1] = 1;
		triangles[2] = 2;
		triangles[3] = 0;
		triangles[4] = 2;
		triangles[5] = 3;
		mesh.vertices = vertices;
		mesh.triangles = triangles;*/
		//mesh.uv = uvs;

		//Debug.Log("------------------------" +  _polygonCollider.GetTotalPointCount());



		//vertices[0] = transform.position;
		vertices[0] = SightStart.position;
		uvs[0] = new Vector2(vertices[0].x,vertices[0].y);
		//float angle = 90.0f;
		float angle = initialAngle;
		float angleoffset = (Mathf.Abs(initialAngle - lastAngle)) / RaysToShoot;
		//RaysToShoot = (int)(Mathf.Abs(initialAngle - lastAngle));

		//for (int i = 1; i < RaysToShoot + 1; i++)
		for (int i = 1; i < RaysToShoot + 1; i++)
		{
			float x = Mathf.Sin(angle);
			float y = Mathf.Cos(angle);
			//angle += 2*Mathf.PI/(RaysToShoot*2);
			angle -= angleoffset;
			//angle--;

			Vector3 dir = new Vector3(x,y,0);
			Vector3 endPoint = SightStart.position + dir * distance;
			//Debug.DrawLine(SightStart.position, endPoint, Color.blue);

			RaycastHit2D hit = Physics2D.Linecast(SightStart.position, endPoint, 1 << LayerMask.NameToLayer("Enemy"));
			if (hit.point != new Vector2(0,0)) 
			{	
				//Debug.DrawLine(SightStart.position, hit.point, Color.green);
				//Vector3 tmp = SightStart.transform.InverseTransformPoint(hit.point);
				//uvs[i] = Vector2(tmp.x,tmp.z);	
				vertices[i] = new Vector3(hit.point.x, hit.point.y, 1);

				//Vector3 tmp = new Vector3(hit.point.x, hit.point.y, 1);
				//Vector3 tmp2 = new Vector3(hit.point.x + 1, hit.point.y - 1, 1);
				myListlight.Add(new Vector3(hit.point.x, hit.point.y, 1));
				myListlight2.Add(new Vector3(hit.point.x + xoffset * factor, hit.point.y + yoffset * factor, 1));
				//myListlight.Add(tmp);
				//myListlight2.Add(tmp2);

				//Vector2 tmp3 = new Vector2(tmp.x, tmp.y);
				//Vector2 tmp4 = new Vector2(tmp2.x, tmp2.y);

				myList.Add(new Vector2(hit.point.x, hit.point.y));
				myList2.Add(new Vector2(hit.point.x + xoffset * factor, hit.point.y + yoffset * factor));
				//myList.Add(tmp3);
				//myList2.Add(tmp4);


			}
			else
			{
				//Debug.DrawLine(SightStart.position, endPoint, Color.green);
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
		mesh.vertices = vertices;
		mesh.triangles = triangles;
		mesh.uv = uvs;

		Vector3[] pathLigth = new Vector3[myList.Count * 2];
		Vector2[] path = new Vector2[myList.Count * 2];
		for(int i = 0; i < myList.Count; i++)
		{
			path[i] = myList[i];
			pathLigth[i] = myListlight[i];
			lineRenderer.SetPosition(i,pathLigth[i] + new Vector3((xoffset * factor)/2, (yoffset * factor)/2,0));

		}

		for(int i = 0; i < myList2.Count; i++)
		{
			path[i + myList2.Count] = myList2[myList2.Count - i - 1];
			pathLigth[i + myList2.Count] = myListlight2[myList2.Count - i - 1];
		}

		triangles2 = new int[(myList.Count -1) * 6];

		for(int i = 0; i < path.Length / 2 -1;i++)
		{
			triangles2[i * 6] = i;
			triangles2[i * 6 + 1] = path.Length - i - 1;
			triangles2[i * 6 + 2] = path.Length - i - 2;

			triangles2[i * 6 + 3] = i;
			triangles2[i * 6 + 4] = i + 1;
			triangles2[i * 6 + 5] = path.Length - i - 2;
		}


		/*mesh2.vertices = pathLigth;
		mesh2.triangles = triangles2;
		mesh2.uv = path;*/

		_polygonCollider.SetPath(0,path);
		myList.Clear();
		myList2.Clear();
		myListlight.Clear();
		myListlight2.Clear();

		#region movimiento

		//transform.position += new Vector3(directionX, directionY, 0);



		#endregion
	}

	void Initialize()
	{
		/*float angle = 0.0f;
		for (int i = 0; i < RaysToShoot; i++)
		{
			float x = Mathf.Sin(angle);
			float y = Mathf.Cos(angle);
			angle += 2*Mathf.PI/RaysToShoot;

			Vector3 dir = new Vector3(x,y,0);

			Vector3 endPoint = SightStart.position + dir * distance;

			Debug.DrawLine(SightStart.position, endPoint, Color.blue);
			RaycastHit2D hit = Physics2D.Linecast(SightStart.position, endPoint, 1 << LayerMask.NameToLayer("Enemy"));
			if (hit != null) 
			{	
				Debug.DrawLine(SightStart.position, hit.point, Color.green);
				//Vector3 tmp = SightStart.transform.InverseTransformPoint(hit.point);
				//vertices2d[i] = Vector2(tmp.x,tmp.z);	
			}
		}*/


		/*vertices[0] = SightEnd.position;
		vertices[1] = SightStart.position;
		vertices[2] = SightEnd2.position;
		for(int i = 0; i < 3; i++)
		{
			uvs[i] = new Vector2(vertices[i].x,vertices[i].y);
		}

		triangles[0] = 0;
		triangles[1] = 1;
		triangles[2] = 2;

		mesh.vertices = vertices;
		mesh.triangles = triangles;
		mesh.uv = uvs;*/
	}

	void RayCasting()
	{
		Debug.DrawLine(SightStart.position, SightEnd.position, Color.blue);
		Debug.DrawLine(SightStart.position, SightEnd2.position, Color.blue);
		Debug.DrawLine(SightStart.position, SightEnd3.position, Color.blue);
		spooted = Physics2D.Linecast(SightStart.position, SightEnd.position, 1 << LayerMask.NameToLayer("Enemy"));
		spooted2 = Physics2D.Linecast(SightStart.position, SightEnd2.position, 1 << LayerMask.NameToLayer("Enemy"));
		spooted3 = Physics2D.Linecast(SightStart.position, SightEnd3.position, 1 << LayerMask.NameToLayer("Enemy"));
	}

	public void modificarAngulos(int sentido, float grados)
	{
		initialAngle += sentido * grados;
		lastAngle += sentido * grados;
	}

	void Behaviors()
	{

	}
}
