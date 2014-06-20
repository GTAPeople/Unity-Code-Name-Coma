using UnityEngine;
using System.Collections;

public class PlayerBall2 : MonoBehaviour {

	private float speed = 0.0f;

	private float directionX = 0.1f;
	private float directionY = -0.1f;
	private float radio = 1.0f;


	private float Xtemp = 0;
	private float Ytemp = 0;

	private int desplazamiento = 0;


	private bool rotar = false;
	private float angle = 0.0f;
	private float anguloActual = 0.0f;
	private int directionAngulo = 1;
	private float grados = Mathf.PI/180;

	private RayCast2d _rayCast2d;

	// Use this for initialization
	void Start () {
		_rayCast2d = GetComponent<RayCast2d>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 movimiento = new Vector3(0,0,0);
		bool upCollition = false;
		bool downCollition = false;
		bool leftCollition = false;
		bool rightCollition = false;

		if(rotar)
		{
			//Debug.Log(anguloActual + "  " + angle + " " + directionAngulo);
			//Debug.Log(anguloActual * 180 / Mathf.PI + "  " + angle* 180 / Mathf.PI + " " + directionAngulo);
			_rayCast2d.modificarAngulos(directionAngulo, grados);
			anguloActual += directionAngulo * grados;
			//Debug.Log(anguloActual + "  " + angle + " " + directionAngulo);
			//Debug.Log(anguloActual * 180 / Mathf.PI + "  " + angle* 180 / Mathf.PI + " " + directionAngulo);
			if(directionAngulo > 0)
			{
				if(anguloActual >= angle)
				{
					anguloActual = 0.0f;
					rotar = false;
				}
			}
			else
			{
				if(anguloActual <= angle)
				{
					anguloActual = 0.0f;
					rotar = false;
				}
			}
		}
		else
		{

		if(desplazamiento == 0)
		{
			transform.position += new Vector3(directionX, directionY, 0);
		}
		Vector3 up = new Vector3(transform.position.x, transform.position.y + radio, transform.position.z);
		Vector3 down = new Vector3(transform.position.x, transform.position.y - radio, transform.position.z);
		Vector3 left = new Vector3(transform.position.x - radio, transform.position.y, transform.position.z);
		Vector3 right = new Vector3(transform.position.x + radio, transform.position.y, transform.position.z);
		
		Debug.DrawLine(transform.position, up, Color.green);
		Debug.DrawLine(transform.position, down, Color.green);
		Debug.DrawLine(transform.position, left, Color.green);
		Debug.DrawLine(transform.position, right, Color.green);

		if(desplazamiento == 0 && Xtemp == 0 && Ytemp == 0)
		{
				RaycastHit2D hitUp = Physics2D.Linecast(transform.position, up, 1 << LayerMask.NameToLayer("mapa"));
				RaycastHit2D hitDown = Physics2D.Linecast(transform.position, down, 1 << LayerMask.NameToLayer("mapa"));
				RaycastHit2D hitLeft = Physics2D.Linecast(transform.position, left, 1 << LayerMask.NameToLayer("mapa"));
				RaycastHit2D hitRight = Physics2D.Linecast(transform.position, right, 1 << LayerMask.NameToLayer("mapa"));
			
			if(hitDown.point != new Vector2(0,0))
			{
				Debug.Log("1");

				if(Vector2.Distance(hitDown.point,new Vector2(transform.position.x, transform.position.y)) < radio)
				{
					movimiento += new Vector3(0, radio - (transform.position.y - hitDown.point.y),0);
				}
				downCollition = true;

				if(leftCollition)
				{
					directionX = -directionX;
				}
			}
			
			if(hitRight.point != new Vector2(0,0))
			{
				Debug.Log("2");


				if(Vector2.Distance(hitRight.point,new Vector2(transform.position.x, transform.position.y)) < radio)
				{
					movimiento -= new Vector3(radio - (hitRight.point.x - transform.position.x),0,0);
				}
				rightCollition = true;
				
				if(downCollition)
				{
					directionY = -directionY;
					
					int aumento = 10;
					float radioMayor = 3 * radio;
					float anguloGiro = 0.0f;
					
					//angle = -90 * Mathf.PI /180;
					angle = 0.0f;

					for (int i = (int)anguloGiro; i < 180; i+= aumento)
					{
						float x = Mathf.Sin(i * Mathf.PI / 180);
						float y = Mathf.Cos(i * Mathf.PI / 180);

						Vector3 uptmp = new Vector3(transform.position.x + radioMayor * y, transform.position.y + radioMayor * x, transform.position.z);
							RaycastHit2D hitUptmp = Physics2D.Linecast(transform.position, uptmp, 1 << LayerMask.NameToLayer("mapa"));
						Debug.DrawLine(transform.position, uptmp, Color.green);
						
						if (hitUptmp.point == new Vector2(0,0))
						{
							angle += - (i + aumento) * Mathf.PI / 180 ;
							break;
						}
					}

					//Debug.Log(angle * 180 / Mathf.PI);
					//angle = -90 * Mathf.PI /180;
					rotar = true; 
					directionAngulo = -1;
				}

			}
			
			if(hitUp.point != new Vector2(0,0))
			{
				Debug.Log("3");

				if(Vector2.Distance(hitUp.point,new Vector2(transform.position.x, transform.position.y)) < radio)
				{
					movimiento -= new Vector3(0, radio - (hitUp.point.y - transform.position.y),0);
				}
				upCollition = true;

				if(leftCollition)
				{
					directionY = -directionY;
				}

				if(rightCollition)
				{
					directionX = -directionX;

						if(rotar == false)
						{
							int aumento = 10;
							float radioMayor = 3 * radio;
							float anguloGiro = 90;
							angle = 0.0f;
							
							float inicioAngulo = 0.0f;
							float finAngulo = 0.0f;
							bool inicioFin = true;
							
							for (int i = (int)anguloGiro; i < 270; i+= aumento)
							{
								float x = Mathf.Sin(i * Mathf.PI / 180);
								float y = Mathf.Cos(i * Mathf.PI / 180);
								
								Vector3 uptmp = new Vector3(transform.position.x + radioMayor * y, transform.position.y + radioMayor * x, transform.position.z);
								RaycastHit2D hitUptmp = Physics2D.Linecast(transform.position, uptmp, 1 << LayerMask.NameToLayer("mapa"));
								//Debug.DrawLine(transform.position, uptmp, Color.green);
								
								if(inicioFin)
								{
									if (hitUptmp.point != new Vector2(0,0))
									{
										Debug.DrawLine(transform.position, uptmp, Color.green);
										inicioAngulo -= (i) * Mathf.PI / 180 ;
										inicioFin = false;
									}
								}
								else
								{
									if (hitUptmp.point == new Vector2(0,0))
									{
										Debug.DrawLine(transform.position, uptmp, Color.green);
										finAngulo -= (i + aumento) * Mathf.PI / 180 ;
										break;
									}
								}
							}
							angle = (finAngulo - inicioAngulo);
							//Debug.Log(angle * 180 / Mathf.PI);
							rotar = true; 
							directionAngulo = -1;
						}
				}

			}
			
			if(hitLeft.point != new Vector2(0,0))
			{
				Debug.Log("4");

				if(Vector2.Distance(hitLeft.point,new Vector2(transform.position.x, transform.position.y)) < radio)
				{
					movimiento += new Vector3(radio - (transform.position.x - hitLeft.point.x),0,0);
				}
				leftCollition = true;

				if(downCollition)
				{
					Debug.Log("4.1");

					directionX = -directionX;

						if(rotar == false)
						{
							int aumento = 10;
							float radioMayor = 3 * radio;
							float anguloGiro = 270;
							angle = 0.0f;
							
							float inicioAngulo = 0.0f;
							float finAngulo = 0.0f;
							bool inicioFin = true;
							
							for (int i = (int)anguloGiro; i < 450; i+= aumento)
							{
								float x = Mathf.Sin(i * Mathf.PI / 180);
								float y = Mathf.Cos(i * Mathf.PI / 180);
								
								Vector3 uptmp = new Vector3(transform.position.x + radioMayor * y, transform.position.y + radioMayor * x, transform.position.z);
								RaycastHit2D hitUptmp = Physics2D.Linecast(transform.position, uptmp, 1 << LayerMask.NameToLayer("mapa"));
								//Debug.DrawLine(transform.position, uptmp, Color.green);
								
								if(inicioFin)
								{
									if (hitUptmp.point != new Vector2(0,0))
									{
										Debug.DrawLine(transform.position, uptmp, Color.green);
										inicioAngulo -= (i) * Mathf.PI / 180 ;
										inicioFin = false;
									}
								}
								else
								{
									if (hitUptmp.point == new Vector2(0,0))
									{
										Debug.DrawLine(transform.position, uptmp, Color.green);
										finAngulo -= (i - 2 * aumento) * Mathf.PI / 180 ;
										break;
									}
								}
							}
							angle = (finAngulo - inicioAngulo);
							Debug.Log(angle * 180 / Mathf.PI);
							rotar = true; 
							directionAngulo = -1;
						}
				}

				if(upCollition)
				{
					Debug.Log("4.2");
					directionY = -directionY;

						if(rotar == false)
						{
							int aumento = 10;
							float radioMayor = 3 * radio;
							float anguloGiro = 180;
							angle = 0.0f;
							
							float inicioAngulo = 0.0f;
							float finAngulo = 0.0f;
							bool inicioFin = true;
							
							for (int i = (int)anguloGiro; i < 360; i+= aumento)
							{
								float x = Mathf.Sin(i * Mathf.PI / 180);
								float y = Mathf.Cos(i * Mathf.PI / 180);
								
								Vector3 uptmp = new Vector3(transform.position.x + radioMayor * y, transform.position.y + radioMayor * x, transform.position.z);
								RaycastHit2D hitUptmp = Physics2D.Linecast(transform.position, uptmp, 1 << LayerMask.NameToLayer("mapa"));
								//Debug.DrawLine(transform.position, uptmp, Color.green);
								
								if(inicioFin)
								{
									if (hitUptmp.point != new Vector2(0,0))
									{
										Debug.DrawLine(transform.position, uptmp, Color.green);
										inicioAngulo -= (i) * Mathf.PI / 180 ;
										inicioFin = false;
									}
								}
								else
								{
									if (hitUptmp.point == new Vector2(0,0))
									{
										Debug.DrawLine(transform.position, uptmp, Color.green);
										finAngulo -= (i + aumento) * Mathf.PI / 180 ;
										break;
									}
								}
							}
							angle = (finAngulo - inicioAngulo);
							Debug.Log(angle * 180 / Mathf.PI);
							rotar = true; 
							directionAngulo = -1;
						}
				}

				if(rightCollition)
				{
					directionY = -directionY;
					directionX = -directionX;

					if(rotar == false)
					{
						int aumento = 10;
						float radioMayor = 3 * radio;
						float anguloGiro = 270;
						angle = 0.0f;
						
						float inicioAngulo = 0.0f;
						float finAngulo = 0.0f;
						bool inicioFin = true;
						
						for (int i = (int)anguloGiro; i < 450; i+= aumento)
						{
							float x = Mathf.Sin(i * Mathf.PI / 180);
							float y = Mathf.Cos(i * Mathf.PI / 180);
							
							Vector3 uptmp = new Vector3(transform.position.x + radioMayor * y, transform.position.y + radioMayor * x, transform.position.z);
							RaycastHit2D hitUptmp = Physics2D.Linecast(transform.position, uptmp, 1 << LayerMask.NameToLayer("mapa"));
							//Debug.DrawLine(transform.position, uptmp, Color.green);
							
							if(inicioFin)
							{
								if (hitUptmp.point != new Vector2(0,0))
								{
									Debug.DrawLine(transform.position, uptmp, Color.green);
									inicioAngulo -= (i) * Mathf.PI / 180 ;
									inicioFin = false;
								}
							}
							else
							{
								if (hitUptmp.point == new Vector2(0,0))
								{
									Debug.DrawLine(transform.position, uptmp, Color.green);
									finAngulo -= (i - 3*aumento) * Mathf.PI / 180 ;
									break;
								}
							}
						}
						angle = (finAngulo - inicioAngulo);
						Debug.Log(angle * 180 / Mathf.PI);
						rotar = true; 
						directionAngulo = -1;
					}
				}
			}
			
			
			if(directionY > 0 && directionX > 0 && !upCollition && !downCollition && !leftCollition && !rightCollition)
			{
				Debug.Log("5");

				Xtemp = right.x;
				Ytemp = up.y;
				desplazamiento = 1;

			}
			else if (directionY < 0 && directionX > 0 && !upCollition && !downCollition && !leftCollition && !rightCollition)
			{
				Debug.Log("6");

				Xtemp = right.x;
				Ytemp = down.y;
				desplazamiento = 2;

				
			}
			else if (directionY < 0 && directionX < 0 && !upCollition && !downCollition && !leftCollition && !rightCollition)
			{
				Debug.Log("7");

				Xtemp = left.x;
				Ytemp = down.y;
				desplazamiento = 1;
			}
			else if (directionY > 0 && directionX < 0 && !upCollition && !downCollition && !leftCollition && !rightCollition)
			{
				Debug.Log("8");

				Xtemp = left.x;
				Ytemp = up.y;
				desplazamiento = 2;
			}
		}

		if(desplazamiento == 1 && Xtemp != 0 && Ytemp != 0)
		{
			Debug.Log("9");

			if(Mathf.Abs(transform.position.y - Ytemp) >= 0.1f)
			{
				movimiento += new Vector3(0, directionY, 0);
				//Debug.Log("9.1");
			}
			else
			{
				if(Mathf.Abs(transform.position.x - Xtemp) >= 0.1f)
				{
					movimiento += new Vector3(directionX, 0, 0);
					//Debug.Log("9.2");
				}
				else
				{
					desplazamiento = 0;
					Xtemp = 0;
					Ytemp = 0;
					directionY = -directionY;

					//Debug.Log("9.3");

				}
			}
			
			if(rotar == false)
			{
				int aumento = 10;
				float radioMayor = 3 * radio;
				float anguloGiro = 270.0f;
				angle = 0.0f;
				
				float inicioAngulo = 0.0f;
				float finAngulo = 0.0f;
				bool inicioFin = true;
				
				for (int i = (int)anguloGiro; i < 450; i+= aumento)
				{
					float x = Mathf.Sin(i * Mathf.PI / 180);
					float y = Mathf.Cos(i * Mathf.PI / 180);
					
					Vector3 uptmp = new Vector3(transform.position.x + radioMayor * y, transform.position.y + radioMayor * x, transform.position.z);
						RaycastHit2D hitUptmp = Physics2D.Linecast(transform.position, uptmp, 1 << LayerMask.NameToLayer("mapa"));
					//Debug.DrawLine(transform.position, uptmp, Color.green);
					
					if(inicioFin)
					{
						if (hitUptmp.point != new Vector2(0,0))
						{
							Debug.DrawLine(transform.position, uptmp, Color.green);
							inicioAngulo -= (i) * Mathf.PI / 180 ;
							inicioFin = false;
						}
					}
					else
					{
						if (hitUptmp.point == new Vector2(0,0))
						{
							Debug.DrawLine(transform.position, uptmp, Color.green);
							finAngulo -= (i + aumento) * Mathf.PI / 180 ;
							break;
						}
					}
				}
				angle = (finAngulo - inicioAngulo);
				//Debug.Log("--> " + angle * 180 / Mathf.PI);
				rotar = true; 
				directionAngulo = 1;
				_rayCast2d.modificarAngulos(directionAngulo, 0.5f * grados);
			}
		}

		if(desplazamiento == 2 && Xtemp != 0 && Ytemp != 0)
		{
			Debug.Log("10");

			if(Mathf.Abs(transform.position.x - Xtemp) >= 0.1f)
			{
				movimiento += new Vector3(directionX, 0, 0);
				//Debug.Log("10.1");
			}
			else
			{
				if(Mathf.Abs(transform.position.y - Ytemp) >= 0.1f)
				{
					movimiento += new Vector3(0, directionY, 0);
					//Debug.Log("10.2");
				}
				else
				{
					desplazamiento = 0;
					Xtemp = 0;
					Ytemp = 0;
					directionX = -directionX;
					//Debug.Log("10.3");
				}
			}

			if(rotar == false)
			{
				int aumento = 10;
				float radioMayor = 3 * radio;
				float anguloGiro = 180.0f;
				angle = 0.0f;
				
				float inicioAngulo = 0.0f;
				float finAngulo = 0.0f;
				bool inicioFin = true;
				
				for (int i = (int)anguloGiro; i > 0; i-= aumento)
				{
					float x = Mathf.Sin(i * Mathf.PI / 180);
					float y = Mathf.Cos(i * Mathf.PI / 180);
					
					Vector3 uptmp = new Vector3(transform.position.x + radioMayor * y, transform.position.y + radioMayor * x, transform.position.z);
						RaycastHit2D hitUptmp = Physics2D.Linecast(transform.position, uptmp, 1 << LayerMask.NameToLayer("mapa"));
					//Debug.DrawLine(transform.position, uptmp, Color.green);
					
					if(inicioFin)
					{
						if (hitUptmp.point != new Vector2(0,0))
						{
							Debug.DrawLine(transform.position, uptmp, Color.green);
							inicioAngulo = (i) * Mathf.PI / 180 ;
							inicioFin = false;
						}
					}
					else
					{
						if (hitUptmp.point == new Vector2(0,0))
						{
							Debug.DrawLine(transform.position, uptmp, Color.green);
							finAngulo = (i) * Mathf.PI / 180 ;
							break;
						}
					}
				}
				//Debug.Log(inicioAngulo * 180/Mathf.PI + " " + finAngulo * 180/Mathf.PI);
				angle = (finAngulo - inicioAngulo);
				//anguloActual += 2 * directionAngulo * grados;
				//Debug.Log("angle: " + angle * 180 / Mathf.PI + "  " + anguloActual);
				rotar = true; 
				directionAngulo = 1;
				
					//Debug.Log("--> " + angle * 180 / Mathf.PI);
					_rayCast2d.modificarAngulos(directionAngulo, 0.5f * Mathf.PI/180);
					_rayCast2d.modificarAngulos(directionAngulo, 0.5f * Mathf.PI/180);
					_rayCast2d.modificarAngulos(directionAngulo, 0.5f * Mathf.PI/180);
					_rayCast2d.modificarAngulos(directionAngulo, 0.5f * Mathf.PI/180);
					_rayCast2d.modificarAngulos(directionAngulo, 0.5f * Mathf.PI/180);
					_rayCast2d.modificarAngulos(directionAngulo, 0.5f * Mathf.PI/180);
			}
			
			
			//-----------------
		}


			transform.position += movimiento;
			upCollition = false;
			downCollition = false;
			leftCollition = false;
			rightCollition = false;
		}



		if(transform.position.x > 500)
		{
			transform.position = new Vector3(-30,0,0);
			directionX = 0.1f;
			directionY = -0.1f;
			Xtemp = 0;
			Ytemp = 0;
			desplazamiento = 0;
		}
	}
}
