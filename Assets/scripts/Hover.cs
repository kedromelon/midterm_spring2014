using UnityEngine;
using System.Collections;

public class Hover : MonoBehaviour {

	public float hoverAmount = 1f;
	public float hoverSpeed = 1f;

	// Update is called once per frame
	void Update () {
		transform.position += Vector3.up * Mathf.Sin(Time.time*hoverSpeed)*hoverAmount;
	}
}
