using UnityEngine;
using System.Collections;

public class MenuInput : MonoBehaviour {
	
	public int nextLevel;
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown){
			Application.LoadLevel(nextLevel);
		}
	}
}
