using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	[HideInInspector]
	public bool facingRight = true;			// For determining which way the player is currently facing.

	public float moveForce = 365f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 10f;				// The fastest the player can travel in the x axis.
	public float jumpForce = 450f;			// Amount of force added when the player jumps.
	public Transform groundCheck;			// A position marking where to check if the player is grounded.

//	bool _doubleJump = false;

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
		if(Input.GetKeyDown(KeyCode.Space) && grounded){
			anim.SetBool("Ground",false);
			rigidbody2D.AddForce(new Vector2(0,jumpForce));
			
			//			if(!_doubleJump && !_grounded){
			//				_doubleJump = true;
			//			}
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
		}

//		if (!_grounded){
//			return;
//		}


		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);

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
