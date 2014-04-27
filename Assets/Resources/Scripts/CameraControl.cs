using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]

public class CameraControl : MonoBehaviour {

	public GameObject player;
	public Vector3 myPos;

	// Use this for initialization
	void Start () {
		audio.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = player.transform.position + myPos;
	}
}
