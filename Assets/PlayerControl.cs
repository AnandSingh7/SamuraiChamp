using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float maxSpeed = .01f;

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		float move = Input.GetAxis ("Horizontal");

		anim.SetFloat ("Speed", Mathf.Abs (move));

		rigidbody2D.velocity = new Vector2 (move * maxSpeed/20, rigidbody2D.velocity.y);


	}

}
