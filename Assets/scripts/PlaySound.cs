using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {

	AudioClip sound;


	void OnTriggerEnter(Collider c){
		GetComponent<AudioSource>().PlayOneShot(sound);
	}
}
