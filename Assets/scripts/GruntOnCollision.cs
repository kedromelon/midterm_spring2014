using UnityEngine;
using System.Collections;

public class GruntOnCollision : MonoBehaviour {

	void OnControllerColliderHit(ControllerColliderHit c){
		if (c.gameObject.tag == "Obstacle"){
			ScreenShake2D.Shake(.25f,.5f);
			GetComponent<AudioSource>().Play();
			StartCoroutine("EndAfterSeconds");
		}
	}

	IEnumerator EndAfterSeconds(){
		GetComponent<MovePlayer>().enabled = false;
		yield return new WaitForSeconds(.5f);
		ScreenShake2D.Shake(0f,0f);
		Application.LoadLevel(Application.loadedLevel);
	}
}
