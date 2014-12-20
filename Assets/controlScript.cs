using UnityEngine;
using System.Collections;

public class controlScript : MonoBehaviour {

	public float runMultiplier;
	public float maxSpeed = 3f;
	private float speed;
	bool facingRight = true;

	Animator anim;

	bool grounded = false;
	bool crouched = false;
	bool lookingUp = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	public KeyCode crouch;
	public KeyCode sprint;
	public KeyCode lookUp;
	public KeyCode slash;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}

	void FixedUpdate() {

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);

		speed = Input.GetKey (KeyCode.LeftShift) ? maxSpeed * runMultiplier : maxSpeed;

		float move = Input.GetAxis ("Horizontal");

		rigidbody2D.velocity = new Vector2 (move * speed, rigidbody2D.velocity.y);

		anim.SetBool("Ground", grounded);

		anim.SetBool ("Crouch", crouched);

		anim.SetBool ("LookUp", lookingUp);

		// anim.SetFloat ("vSpeed", rigidbody2D.velocity.y); //branch falling animation

		anim.SetFloat ("Speed", Mathf.Abs(move));

		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();
	}

	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void Jump() {
		if (grounded && Input.GetKeyDown(KeyCode.Space)) {
			anim.SetBool("Ground", false);
			rigidbody2D.AddForce(new Vector2(0, 700f));
		}
	}

	void Crouch() {
		crouched = (grounded && Input.GetKey(crouch));
	}

	void LookUp(){
		lookingUp = (grounded && (Input.GetAxis ("Horizontal") < 0.1) && Input.GetKey (lookUp));
	}
	
	// Update is called once per frame
	void Update () {
		Jump ();
		Crouch ();
		LookUp ();
	}
}
