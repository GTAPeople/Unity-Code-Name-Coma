#pragma strict

public var lightmeshholder:GameObject;

private var RaysToShoot:int=10240; //64; 128; 1024; 
private var distance:int=10 ;
private var vertices : Vector3[];
private var vertices2d : Vector2[];
private var vertices2dLength : int;
private var triangles : int[];
private var mesh : Mesh;

function Start () {
	vertices2d = new Vector2[RaysToShoot];
	mesh= lightmeshholder.GetComponent(MeshFilter).mesh;
	BuildVertices2d ();
	BuildMesh();
}

function Update () {

	vertices = mesh.vertices;
	Debug.Log(vertices.Length);
	
	var angle:float = 0;
	for (var i:int = 0; i < RaysToShoot; i++)
	{
		var x = Mathf.Sin(angle);
		var y = Mathf.Cos(angle);
		
		//360 grades
		angle += 2*Mathf.PI / RaysToShoot;
		
		var dir:Vector3 = Vector3(x,y,0);
		
		var hit : RaycastHit;
		if (Physics.Raycast (transform.position, dir, hit, distance)) 
		{	
			var tmp = lightmeshholder.transform.InverseTransformPoint(hit.point);
			vertices[i] = Vector3(tmp.x, tmp.y, 0);
		}
		else
		{ // no hit
			var tmp2 = lightmeshholder.transform.InverseTransformPoint(lightmeshholder.transform.position + dir);
			vertices[i] = Vector3(tmp2.x, tmp2.y, 0);
		}
	}
	vertices[i] = lightmeshholder.transform.InverseTransformPoint(transform.position);
	mesh.vertices = vertices;
}

function BuildVertices2d () 
{ 
	Debug.Log("1");
	var angle:float = 0;
	var j : int = 0;
	for (var i:int = 0; i < RaysToShoot; i++)
	{
		var x = Mathf.Sin(angle);
		var y = Mathf.Cos(angle);
		
		//360 grades
		angle += 2*Mathf.PI / RaysToShoot;
		
		var dir:Vector3 = Vector3(x,y,0);
		
		var hit : RaycastHit;
		if (Physics.Raycast (transform.position, dir, hit, distance)) 
		{	
			var tmp = lightmeshholder.transform.InverseTransformPoint(hit.point);
			vertices2d[i] = Vector2(tmp.x,tmp.y);
			j++;
		}
		else
		{ // no hit
			var tmp2 = lightmeshholder.transform.InverseTransformPoint(lightmeshholder.transform.position+dir);
			vertices2d[i] = Vector2(tmp2.x,tmp2.y);
			j++;
		}
	}
	vertices2dLength = j;
}

function BuildMesh()
{
	Debug.Log("2");
	// build mesh
    var uvs : Vector2[] = new Vector2[vertices2dLength + 1];
    var newvertices : Vector3[] = new Vector3[vertices2dLength + 1];
    
    for (var n : int = 0; n < vertices2dLength; n++) 
	{
        newvertices[n] = new Vector3(vertices2d[n].x, vertices2d[n].y, 0);	
    }
    
    //
    triangles = new int[newvertices.Length * 3];
	    
	// triangle list
	var i = -1;
	for (n = 0; n < triangles.length - 3; n += 3)
	{
		i++;
		triangles[n] = vertices2dLength;
		
		if (i > vertices2dLength)
		{
			triangles[n + 1] = 0;
		}
		else
		{
			triangles[n + 1] = i + 1;
		}
		triangles[n + 2] = i;
	}    
    i++;
    
	// central point
	newvertices[newvertices.Length-1] = new Vector3(0,0,0);
	triangles[triangles.length-3] = newvertices.Length-1;
	triangles[triangles.length-2] = 0;
	triangles[triangles.length-1] = i-1;
	
	mesh.vertices = newvertices;
    mesh.triangles = triangles;
    mesh.uv = uvs;
}
