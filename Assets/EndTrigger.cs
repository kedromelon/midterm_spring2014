using UnityEngine;
using System.Collections;

public class EndTrigger : MonoBehaviour {

	public TextMesh endtext;
	public TextMesh playertext;

	void Start(){
		endtext.renderer.enabled = false;
	}

	void OnTriggerExit(Collider c){
		playertext.renderer.enabled = false;
		endtext.renderer.enabled = true;
		endtext.text = playertext.text;
		CharacterController controller = c.GetComponent<CharacterController>();
		controller.SimpleMove(controller.velocity/10f);
	}
}
