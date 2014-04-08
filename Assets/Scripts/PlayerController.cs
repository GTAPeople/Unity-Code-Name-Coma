using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float _maxSpeed = 10f;
	bool _facingRight = true;

	Animator _animator;

	bool _grounded = false;
	public Transform _groundCheck;
	float _groundRadius = 0.2f;
	public LayerMask _whatIsGround;
	public float _jumpForce = 450f;

//	bool _doubleJump = false;

	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator> ();
	}	

	void FixedUpdate () {

		_grounded = Physics2D.OverlapCircle(_groundCheck.position,_groundRadius,_whatIsGround);
		_animator.SetBool ("Ground",_grounded);

//		if(_grounded){
//			_doubleJump = false;
//		}

		_animator.SetFloat ("vSpeed", rigidbody2D.velocity.y);

//		if (!_grounded){
//			return;
//		}

		float move = Input.GetAxis ("Horizontal");

		_animator.SetFloat ("Speed",Mathf.Abs(move));

		rigidbody2D.velocity = new Vector2 (move * _maxSpeed, rigidbody2D.velocity.y);

		if(move > 0 && !_facingRight){
			Flip();
		}
		else if(move < 0 && _facingRight){
			Flip ();
		}
	}

	// Update is called once per frame
	void Update(){
//		if((_grounded || !_doubleJump) && Input.GetKeyDown(KeyCode.Space)){
		if((_grounded) && Input.GetKeyDown(KeyCode.Space)){
			_animator.SetBool("Ground",false);
			rigidbody2D.AddForce(new Vector2(0,_jumpForce));

//			if(!_doubleJump && !_grounded){
//				_doubleJump = true;
//			}
		}
	}

	void Flip(){
		_facingRight = !_facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
