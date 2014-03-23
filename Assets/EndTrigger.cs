using UnityEngine;
using System.Collections;

public class EndTrigger : MonoBehaviour {

	public TextMesh endtext;
	public TextMesh playertext;

	void Start(){
		endtext.renderer.enabled = false;
	}

	void OnTriggerExit(Collider c){
		if (c.GetComponent<CharacterController>() != null){
			playertext.renderer.enabled = false;
			endtext.renderer.enabled = true;
			endtext.text = playertext.text;
			CharacterController controller = c.GetComponent<CharacterController>();
			controller.SimpleMove(controller.velocity/10f);
		}
	}
}
