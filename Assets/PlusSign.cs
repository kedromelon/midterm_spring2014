using UnityEngine;
using System.Collections;

public class PlusSign : MonoBehaviour {

	Vector3 startposition;
	TextMesh text;
	float r;
	float speed;

	// Use this for initialization
	void Start () {
		startposition = transform.position;
		text = GetComponent<TextMesh>();
		r = Random.Range(-2f,2f);
		speed = Random.Range(3f,6f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += (Vector3.up + Vector3.right*r).normalized * Time.deltaTime * speed;
		Color color = text.renderer.material.color;
		color.a -= Time.deltaTime * 2f;
		text.renderer.material.color = color;
		speed *= .9f;
	}
}
