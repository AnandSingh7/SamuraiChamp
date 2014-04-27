using UnityEngine;
using System.Collections;

public class ScoreText : MonoBehaviour {
	public TextMesh text;
	public Vector3 Offset = Vector3.zero;
	public int score = 0;
	// Use this for initialization
	void Start () {
		text = new GameObject ("Text").AddComponent ("TextMesh") as TextMesh;
		text.gameObject.transform.parent = transform;
		text.transform.localPosition = Vector3.zero + Offset;
		text.GetComponent<MeshRenderer>().sortingLayerID = 2;
		text.GetComponent<MeshRenderer>().sortingOrder = 3;
		
		
		text.font = Resources.Load ("Fonts/Lemiesz") as Font;
		text.renderer.material = text.font.material;
		text.characterSize = 0.03f;
		text.alignment = TextAlignment.Center;
		text.anchor = TextAnchor.MiddleCenter;
		text.fontSize = 100;
	}
	
	// Update is called once per frame
	void Update () {
		text.text = score.ToString();
	}
}
