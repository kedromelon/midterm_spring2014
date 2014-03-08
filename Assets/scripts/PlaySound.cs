using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {

	//public AudioClip sound;


	void OnTriggerEnter(Collider c){
		GetComponent<AudioSource>().Play();
	}
}
