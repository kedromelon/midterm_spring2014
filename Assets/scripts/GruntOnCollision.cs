using UnityEngine;
using System.Collections;

public class GruntOnCollision : MonoBehaviour {

	void OnControllerColliderHit(ControllerColliderHit c){
		if (c.gameObject.tag == "Obstacle"){
			GetComponent<AudioSource>().Play();
			StartCoroutine("EndAfterSeconds");
		}
	}

	IEnumerator EndAfterSeconds(){
		GetComponent<MovePlayer>().enabled = false;
		yield return new WaitForSeconds(.5f);
		Application.LoadLevel(Application.loadedLevel);
	}
}
