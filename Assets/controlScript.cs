using UnityEngine;
using System.Collections;

public class controlScript : MonoBehaviour {

	public float maxSpeed = 10f;
	bool facingRight = true;

	Animator anim;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate() {

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
	

		float move = Input.GetAxis ("Horizontal");

		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
		anim.SetBool ("Ground", grounded);

		anim.SetFloat ("Speed", Mathf.Abs (move)); //branch falling animation

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

	// Update is called once per frame
	void Update () {
		if (grounded && Input.GetKeyDown (KeyCode.Space)) {
			anim.SetBool("Ground", false);
			rigidbody2D.AddForce(new Vector2(0, 700f));
		}
	}
}
