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
}
