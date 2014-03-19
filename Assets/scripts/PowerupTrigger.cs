using UnityEngine;
using System.Collections;

public class PowerupTrigger : MonoBehaviour {

	public TextMesh powerupcounter;

	public int powerups;

	public GameObject getparticle;
	public GameObject useparticle;

	public AudioClip getsound;
	public AudioClip usesound;

	void Start(){
		powerups = 0;
		powerupcounter.text = powerups.ToString();
	}

	void OnTriggerEnter(Collider c){
		if (c.gameObject.tag == "Obstacle"){
			if (powerups > 0){
				DestroyObstacle(c);
			}
		}
		if (c.gameObject.tag == "Powerup"){
			powerups++;
			Destroy(c.gameObject);
			Instantiate(getparticle, c.transform.position, getparticle.transform.rotation);
			GetComponent<AudioSource>().PlayOneShot(getsound);
			powerupcounter.text = powerups.ToString();
		}
	}

	public void DestroyObstacle(Collider c){
		ScreenShake2D.Shake(.25f,1f);
		Destroy(c.gameObject);
		Instantiate(useparticle, c.transform.position, useparticle.transform.rotation);
		GetComponent<AudioSource>().PlayOneShot(usesound);
		transform.parent.GetComponent<MovePlayer>().scoremanager.IncrementScore();
		powerups--;
		powerupcounter.text = powerups.ToString();
	}
}
