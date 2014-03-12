using UnityEngine;
using System.Collections;

public class MenuInput : MonoBehaviour {
	
	public string nextLevel = "typeInSceneNameHere";
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown){
			Application.LoadLevel(nextLevel);
		}
	}
}
