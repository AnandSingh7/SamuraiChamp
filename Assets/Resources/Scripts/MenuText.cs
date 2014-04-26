using UnityEngine;
using System.Collections;

public class MenuText : MonoBehaviour {

	public Renderer[] menuText;

	// Use this for initialization
	void Start () {
		menuText = GetComponentsInChildren<Renderer> ();
		foreach (Renderer r in menuText) {
			r.sortingLayerID = 2;
			r.sortingOrder = 3;
			Debug.Log ("Sorting layer" + r.sortingLayerName);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
