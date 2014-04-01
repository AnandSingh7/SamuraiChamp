using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D hit)
	{
		if (hit.tag == "Ground") {
			SendMessageUpwards("isGrounded");
		}
	}
}
