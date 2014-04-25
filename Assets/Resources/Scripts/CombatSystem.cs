using UnityEngine;
using System.Collections;

public class CombatSystem : MonoBehaviour {
	public CharacterController controller;
	public int health = 50;
	public float knockbackX = 20F;
	public float knockbackY = 1F;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0){
			Application.LoadLevel("Main Menu");  
		}
	}
	
	void onControllerColliderHit(ControllerColliderHit hit){
		if (hit.gameObject.tag == "Enemy"){
			health -= 10;
			controller.Move(new Vector2(-knockbackX, knockbackY));
		}
	}
}