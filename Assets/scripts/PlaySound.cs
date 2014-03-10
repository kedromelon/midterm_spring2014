using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {
	
	void OnTriggerEnter(Collider c){
		GetComponent<AudioSource>().Play();
	}
}
