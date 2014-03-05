using UnityEngine;
using System.Collections;

public class Gaia : MonoBehaviour {

	public int treesToMake = 200;
	float rangeToMake = 200f;

	public GameObject tree;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < treesToMake; i++){
			//Vector3 randomVector = Random.insideUnitSphere * rangeToMake;
			//Vector3 place = new Vector3(randomVector.x, 1f, randomVector.z);
			//Instantiate(tree, place, Quaternion.identity);

			Instantiate(tree, new Vector3(
				Random.Range(collider.bounds.min.x, collider.bounds.max.x),
				1f,
				Random.Range(collider.bounds.min.z, collider.bounds.max.z)), Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
