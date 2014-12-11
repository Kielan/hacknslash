using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {
	
	public float speed = 6f;            // The speed that the player will move at.
	public float acceleration = 12;
	public float timeBetweenSlash = 0.15f; //time between attacks
	/*
	public KeyCode left;
	public KeyCode right;
	public KeyCode slash;
*/
	private float currentSpeed;
	private float targetSpeed;
	private Vector2 amountToMove;

	Vector3 movement;                   // The vector to store the direction of the player's movement.
	Rigidbody2D playerRigidbody;          // Reference to the player's rigidbody2D component
	int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
	int facing;							//tracks the direction the player is facing
	float camRayLength = 100f;          // The length of the ray from the camera into the scene.

	void Awake () {

		// Set up references.
		playerRigidbody = GetComponent <Rigidbody2D> ();

	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*
		void FixedUpdate ()
		{

				if (Input.GetKeyDown (left)) {
			
			
						rigidbody2D.AddForce (Vector3.left * 10);
			
						float step = 1 * Time.deltaTime;
				}
				if (Input.GetKeyDown (right)) {
			
						rigidbody2D.AddForce (Vector3.right * 10);
			
						float step = 1 * Time.deltaTime;
				}
		
				// Animate the player.
				//			Animating (h, v);
		
				// Attack
				//	Attack ();
		}
*/

	void update () {
		targetSpeed = Input.GetAxisRaw("Horizontal") * speed;
		currentSpeed = IncrementTowards (currentSpeed, targetSpeed, acceleration);

		amountToMove.x = currentSpeed;

	}
	private float IncrementTowards(float n, float target, float acceleration) {
		if (n == target) {
			return n;
				}
		else {
			float dir = Mathf.Sign(target - n); //increase or decrease makes closer to target
			n += acceleration * Time.deltaTime * dir;
			return (dir == Mathf.Sign(target-n))? n: target;

		}
	}
}

