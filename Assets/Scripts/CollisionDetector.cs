using UnityEngine;
using System.Collections;

public class CollisionDetector : MonoBehaviour
{
	
		public Transform wallDetector;
		public Transform groundDetector1;
		public Transform groundDetector2;
		public Transform angleDetector;
	
		public bool IsTouchingWall { get; private set; }
	
		public bool IsGrounded { get; private set; }

		public float currentGroundAngle;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{

		
				Debug.DrawLine (transform.position, wallDetector.position, Color.green);
				Debug.DrawLine (transform.position, groundDetector1.position, Color.red);
				Debug.DrawLine (transform.position, angleDetector.position, Color.black);

				RaycastHit2D wallHit = Physics2D.Linecast (transform.position, wallDetector.position, 1 << LayerMask.NameToLayer ("Wall"));
			

				if (wallHit.collider != null)
						IsTouchingWall = true;
				else
						IsTouchingWall = false;
				
				IsGrounded = Physics2D.Linecast (transform.position, groundDetector1.position, 1 << LayerMask.NameToLayer ("Ground"));
				if (IsGrounded == false)		
						IsGrounded = Physics2D.Linecast (transform.position, groundDetector2.position, 1 << LayerMask.NameToLayer ("Ground"));



				RaycastHit2D GroundHit = Physics2D.Linecast (transform.position, angleDetector.position, 1 << LayerMask.NameToLayer ("Ground"));
	
				if (GroundHit.collider != null) {
						currentGroundAngle = GroundHit.transform.eulerAngles.z;
				} else {
						currentGroundAngle = 0;
				}
		}
}
