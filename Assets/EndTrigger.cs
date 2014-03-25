using UnityEngine;
using System.Collections;

public class EndTrigger : MonoBehaviour {

	public TextMesh endtext;
	public TextMesh playertext;
	public TextMesh poweruptext;

	public ScoreManager scoremanager;

	void Start(){
		endtext.renderer.enabled = false;
	}

	void OnTriggerExit(Collider c){
		if (c.GetComponent<CharacterController>() != null){
			scoremanager.isStopped = true;
			playertext.renderer.enabled = false;
			poweruptext.renderer.enabled = false;
			endtext.renderer.enabled = true;
			endtext.text = "Score: " + (float.Parse(playertext.text) + float.Parse(poweruptext.text)).ToString();
			CharacterController controller = c.GetComponent<CharacterController>();
			controller.SimpleMove(controller.velocity/10f);
			GetComponent<AudioSource>().Play();
		}
	}
}
