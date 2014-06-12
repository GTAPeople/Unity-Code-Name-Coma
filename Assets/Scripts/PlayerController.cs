using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

	public float speed = 10f;				// The fastest the player can travel in the x axis.
	public float jumpForce = 450f;			// Amount of force added when the player jumps.
	public Transform groundCheck;			// A position marking where to check if the player is grounded.

	//Platform Set
	private Transform currentPlatform = null;
	private Vector3 lastPlatformPosition = Vector3.zero;
	private Vector3 currentPlatformDelta = Vector3.zero;

//	bool _doubleJump = false;

	private bool facingRight = true;			// For determining which way the player is currently facing.
	private bool grounded = false;			// Whether or not the player is grounded.
	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}	

	// Update is called once per frame
	void Update(){
		// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));  

		anim.SetBool ("Ground",grounded);

		//		if((_grounded || !_doubleJump) && Input.GetKeyDown(KeyCode.Space)){
		// If the jump button is pressed and the player is grounded then the player should jump.
		if((Input.GetKeyDown(KeyCode.UpArrow)||Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.Space)) && grounded){
			rigidbody2D.AddForce(new Vector2(0,jumpForce));
//			anim.SetBool("Ground",false);
			
//						if(!_doubleJump && !_grounded){
			//				_doubleJump = true;
			//			}
		}

		//Moving platform logic
		//Check what platform we are on
		List<Transform> platforms = new List<Transform>();
		bool onSamePlatform = false;
//		foreach(Transform groundCheck in groundChecks)
//		{
			RaycastHit2D hit = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
			if(hit.transform != null)
			{
				platforms.Add(hit.transform);
				if(currentPlatform == hit.transform)
				{
					onSamePlatform = true;
				}
			}

//		}
		
		if(!onSamePlatform)
		{
			foreach(Transform platform in platforms)
			{
				currentPlatform = platform;
				lastPlatformPosition = currentPlatform.position;

			}
		}
		
		if(currentPlatform != null)
		{
			//Determine how far platform has moved
			currentPlatformDelta = currentPlatform.position - lastPlatformPosition;
			
			lastPlatformPosition = currentPlatform.position;
		}
	}

	void LateUpdate()
	{
		if(currentPlatform != null&&grounded)
		{
			//Move with the platform
			transform.position += currentPlatformDelta;
		}
	}

	void FixedUpdate () {

		// Cache the horizontal input.
		float move = Input.GetAxis ("Horizontal");

		// The Speed animator parameter is set to the absolute value of the horizontal input.
		anim.SetFloat ("Speed",Mathf.Abs(move));

//		if(_grounded){
//			_doubleJump = false;
//		}
		if(!grounded){
			anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);
		}else{
			anim.SetFloat ("vSpeed", 0);
		}
//		Debug.Log ((jumpForce/rigidbody2D.mass)*Time.fixedDeltaTime);
//		Debug.Log (rigidbody2D.velocity.y);
//		if (!_grounded){
//			return;
//		}

		rigidbody2D.velocity = new Vector2 (move * speed, rigidbody2D.velocity.y);

		// If the input is moving the player right and the player is facing left...
		if(move > 0 && !facingRight){
			// ... flip the player.
			Flip();
		}
		// Otherwise if the input is moving the player left and the player is facing right...
		else if(move < 0 && facingRight){
			// ... flip the player.
			Flip ();
		}
	}

	void Flip(){
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
}
