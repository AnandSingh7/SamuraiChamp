using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class PlayerControl : MonoBehaviour {

	public Animator anim;

	public float maxSpeed = .01f;
	public bool bGrounded = false;
	public GameObject groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	public float jumpForce = 40f;

	// attack cooldown
	public float nextAttackAllowed;

	// for detecting if an attack hits
	public bool interact = false;
	public Transform lineStart, lineEnd;
	public Transform lineStart2, lineEnd2;
	public Transform lineStart3, lineEnd3;
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


		if (Input.GetButtonDown ("GroundAttack") && nextAttackAllowed <= Time.time) {
			groundAttack ();
			audio.Play ();
			nextAttackAllowed = Time.time + .3f; // player can only attack ever .3second.
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
		audio.Play ();
	}
	
	void raycasting() {
		Debug.DrawLine (lineStart.position, lineEnd.position, Color.green);
		Debug.DrawLine (lineStart2.position, lineEnd2.position, Color.green);
		Debug.DrawLine (lineStart3.position, lineEnd3.position, Color.green);

		if (Physics2D.Linecast (lineStart.position, lineEnd.position, 1 << LayerMask.NameToLayer ("Bat"))) {
			whatIHit = Physics2D.Linecast (lineStart.position, lineEnd.position, 1 << LayerMask.NameToLayer ("Bat"));
			interact = true;
		} else {
			interact = false;
		}
		if (Input.GetButtonDown ("GroundAttack") && interact == true) {
			Destroy (whatIHit.collider.gameObject);
		}
		if (Physics2D.Linecast (lineStart2.position, lineEnd2.position, 1 << LayerMask.NameToLayer ("Bat"))) {
			whatIHit = Physics2D.Linecast (lineStart2.position, lineEnd2.position, 1 << LayerMask.NameToLayer ("Bat"));
			interact = true;
		} else {
			interact = false;
		}
		if (Input.GetButtonDown ("GroundAttack") && interact == true) {
			Destroy (whatIHit.collider.gameObject);
		}
		if (Physics2D.Linecast (lineStart3.position, lineEnd3.position, 1 << LayerMask.NameToLayer ("Bat"))) {
			whatIHit = Physics2D.Linecast (lineStart3.position, lineEnd3.position, 1 << LayerMask.NameToLayer ("Bat"));
			interact = true;
		} else {
			interact = false;
		}
		if (Input.GetButtonDown ("GroundAttack") && interact == true) {
			Destroy (whatIHit.collider.gameObject);
		}
	}
}
