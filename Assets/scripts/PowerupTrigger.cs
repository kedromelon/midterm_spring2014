using UnityEngine;
using System.Collections;

public class PowerupTrigger : MonoBehaviour {

	public TextMesh powerupcounter;

	int powerups;

	public GameObject getparticle;
	public GameObject useparticle;

	void Start(){
		powerups = 0;
		powerupcounter.text = powerups.ToString();
	}

	void OnTriggerEnter(Collider c){
		if (c.gameObject.tag == "Obstacle"){
			if (powerups > 0){
				ScreenShake2D.Shake(.25f,1f);
				Destroy(c.gameObject);
				Instantiate(useparticle, c.transform.position, useparticle.transform.rotation);
				transform.parent.GetComponent<MovePlayer>().scoremanager.IncrementScore();
				powerups--;
				powerupcounter.text = powerups.ToString();
			}
		}
		if (c.gameObject.tag == "Powerup"){
			powerups++;
			Destroy(c.gameObject);
			Instantiate(getparticle, c.transform.position, getparticle.transform.rotation);
			powerupcounter.text = powerups.ToString();
		}
	}
}
