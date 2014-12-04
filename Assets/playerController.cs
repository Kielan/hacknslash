using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {
	
	public float speed = 6f;            // The speed that the player will move at.
	public float timeBetweenSlash = 0.15f; //time between attacks
	
	public KeyCode up;
	public KeyCode down;
	public KeyCode left;
	public KeyCode right;
	public KeyCode slash;
	
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

	void FixedUpdate ()
	{
		
		// Move the player around the scene.
		if(Input.GetKeyDown(up)) {
			
			rigidbody2D.AddForce(Vector3.up * 10);
			
			float step = 1 * Time.deltaTime;
			
			
			
		}
		if(Input.GetKeyDown(down)) {
			
			
			rigidbody.AddForce(Vector3.down * 10);
			
			float step = 1 * Time.deltaTime;
			
			
		}
		if(Input.GetKeyDown(left)) {
			
			
			rigidbody2D.AddForce(Vector3.left * 10);
			
			float step = 1 * Time.deltaTime;
		}
		if(Input.GetKeyDown(right)) {
			
			rigidbody2D.AddForce(Vector3.right * 10);
			
			float step = 1 * Time.deltaTime;
		}
		
		// Animate the player.
		//			Animating (h, v);
		
		// Attack
		//	Attack ();
	}
}

