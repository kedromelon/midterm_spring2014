using UnityEngine;
using System.Collections;

public class TiltCamera : MonoBehaviour {

	public float maxoffset = 2f;
	
	float zoffset = 0f;

	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.A)){
			zoffset = Mathf.Lerp(zoffset, maxoffset, Time.deltaTime);
		}else if (Input.GetKey(KeyCode.D)){
			zoffset = Mathf.Lerp(zoffset, -maxoffset, Time.deltaTime);
		}else {
			zoffset = Mathf.Lerp(zoffset, 0f, Time.deltaTime);
		}

		transform.eulerAngles = new Vector3(9.418701f,0f,zoffset);

	}
}
