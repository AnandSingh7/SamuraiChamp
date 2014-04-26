using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public Animator anim;

	public float maxSpeed = .01f;
	public bool bGrounded = false;
	public GameObject groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	public float jumpForce = 40f;

	// for detecting if an attack hits
	public bool interact = false;
	public Transform lineStart, lineEnd;
	RaycastHit2D whatIHit;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {



		if (bGrounded && Input.GetButtonDown ("Jump")) {
			anim.SetBool("Grounded", false);
			jump ();
		}

		if (Input.GetButtonDown ("GroundAttack")) {
			anim.SetBool ("Grounded", true);
			groundAttack ();
		}

		Physics2D.IgnoreLayerCollision (9, 12);

		raycasting ();

	}

	void FixedUpdate() {

		bGrounded = Physics2D.OverlapCircle (groundCheck.transform.position, groundRadius, whatIsGround);
		anim.SetBool ("Grounded", bGrounded);

		//Move the character
		//float move = Input.GetAxis ("Horizontal");
		float move = 1;

		anim.SetFloat ("Speed", Mathf.Abs (move));
		anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);

		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);

	}

	void isGrounded()
	{
		bGrounded = true;
	}

	void isNotGrounded()
	{
		bGrounded = false;
	}

	void jump() {
		anim.SetTrigger ("Jump");
		rigidbody2D.AddForce (new Vector2(0f,jumpForce));
	}

	void groundAttack() {
		anim.SetTrigger ("GroundAttack");
	}

	void raycasting() {
		Debug.DrawLine (lineStart.position, lineEnd.position, Color.green);

		if (Physics2D.Linecast (lineStart.position, lineEnd.position, 1 << LayerMask.NameToLayer ("Bat"))) {
			whatIHit = Physics2D.Linecast (lineStart.position, lineEnd.position, 1 << LayerMask.NameToLayer ("Bat"));
			interact = true;
		} else {
			interact = false;
		}
		if (Input.GetButtonDown ("GroundAttack") && interact == true) {
			Destroy (whatIHit.collider.gameObject);
		}
	}

}
