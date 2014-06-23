using UnityEngine;
using System.Collections;

public class ControlPlayer : MonoBehaviour
{

		private CollisionDetector collisionState;
		//

		public float _speed = 3f;
		public float _stayOnWallDelay = 8f;
		public Vector2 _jumpForce = new Vector2 (0, 150f);
		public Vector2 _wallJumpForce = new Vector2 (180f, 200f);
		public float _slideDownVelocity = -1f;
		public int _slideStartTime = 0;
		private Animator _animator;
		public float _defaultScale = 10f;



		//
		private int _faceDirection = 1;
	
		//
		private bool _wallJump = false;
		private bool _wallJumpReturn = true;
		private bool _startTimer = false;
	
		//
		
		//
		private 	bool _firstJump;
		public float _timerJump;
	
		void Start ()
		{
		
			transform.localScale = new Vector3 (_defaultScale, _defaultScale, 1);
		
		_timerJump = 0;
				collisionState = GetComponent<CollisionDetector> ();
				_animator = gameObject.GetComponent<Animator> ();
		}

		void Update ()
		{



				if (_wallJump && _startTimer) {

						if (_timerJump < _stayOnWallDelay) {
								_timerJump += 1f;
				
						} else if (_timerJump == _stayOnWallDelay) {
								_wallJumpReturn = true;
								_startTimer = false;
								_slideStartTime = 2;
						}
				}

	
				if (_wallJumpReturn && collisionState.IsTouchingWall) {
						_wallJump = false;	
						_timerJump = 0;
				}

				bool jumpButton = Input.GetButtonDown ("Jump");
		
				bool touchingLeft = Input.GetKey (KeyCode.A);
				bool touchingRigth = Input.GetKey (KeyCode.D);
			

				if (collisionState.IsGrounded) {
						_firstJump = false;
			
						_animator.SetBool ("jump", false);
						if (jumpButton) {
								_animator.SetBool ("jump", true);
								//transform.position += Vector3.up * 100 * Time.deltaTime*10;

								//	simpleJumpForce *= Time.deltaTime;

								if ((touchingLeft || touchingRigth) && collisionState.IsTouchingWall) {
										rigidbody2D.velocity = Vector2.zero;
								}
				
								rigidbody2D.AddForce (new Vector2 (_jumpForce.x * _faceDirection, _jumpForce.y));

								//anim.SetBool("Jump", true);
								//jump = true;_timer = 0;
						} else {


								_timerJump = 0f;
								_wallJump = false;	
						}
			
				} else if (!collisionState.IsGrounded && collisionState.IsTouchingWall) {

						if (jumpButton && (touchingLeft || touchingRigth)) {
				
								_animator.SetBool ("jump", false);
								_firstJump = true;
								_wallJump = true;
								_startTimer = true;
				
								float wallJumpForceX = _wallJumpForce.x;
								wallJumpForceX *= _faceDirection;
								wallJumpForceX *= -1f;
				
								rigidbody2D.velocity = (Vector2.zero);
								rigidbody2D.AddForce (new Vector2 (wallJumpForceX, _wallJumpForce.y));
								_wallJumpReturn = false;
						}
			
						if ((touchingLeft || touchingRigth) && _firstJump) {
								
								if (!_wallJump && !jumpButton) {
										//rigidbody2D.velocity = Vector2.zero;
										if (_slideStartTime == 0) {
												rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, _slideDownVelocity);
										} else {
												_slideStartTime -= 1;
										}
					
					
								}
				
						}

				}
			
				if (_wallJump && (!touchingLeft || !touchingRigth)) {
						//rigidbody2D.velocity = (Vector2.zero);
				}

		}

		void FixedUpdate ()
		{	
		
				float forceX = 0;
		
				float movement = Input.GetAxis ("Horizontal");
		
				if (movement > 0) {
						_faceDirection = 1;
				} else if (movement < 0) {
						_faceDirection = -1;
				}
		
		
				if (movement != 0) {
						forceX = _speed * movement;
						forceX *= Time.deltaTime;
				} 
		
				//transform.position += new Vector3 (forceX, 0f, 0f); 

				if (_wallJumpReturn) {

						transform.Translate (forceX, 0f, 0f);

						rigidbody2D.velocity = new Vector2 (0f, rigidbody2D.velocity.y);
				

						float currentGroundAngle = collisionState.currentGroundAngle;
						float currentPlayerAngle = transform.eulerAngles.z;

				
						if (currentGroundAngle != currentPlayerAngle) {
								var currentRotation = transform.rotation;

								//transform.rotation = Quaternion.Euler (0, 0, currentGroundAngle);

								//transform.rotation = Quaternion.identity;
						}
						
						//currentGround.rotation.z = currentGround.rotation.z;
		

						//_wallJumpReturn = false;
				}

				//var angle = Mathf.Atan2(collisionState.currentGround.position.y, 
				// collisionState.currentGround.position.x) * Mathf.Rad2Deg;

				//	var q = Quaternion.AngleAxis(angle, Vector3.forward);
				//	transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 10f * Time.deltaTime);


				//rigidbody2D.velocity = new Vector2 (forceX, 0f);
		
				Flip ();
				/*float realSpeed = movement * _speed;
				realSpeed *= Time.deltaTime;


			*/

		}

		void Flip ()
		{
				Vector3 newScale = transform.localScale;
				newScale = new Vector3 (_defaultScale * _faceDirection, _defaultScale, 1);
		
				transform.localScale = newScale;
		}


}
