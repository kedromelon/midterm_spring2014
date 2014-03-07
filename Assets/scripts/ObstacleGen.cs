using UnityEngine;
using System.Collections;

public class ObstacleGen : MonoBehaviour {

	public int thingsToMake = 200;

	public GameObject thing;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < thingsToMake; i++){
			//Vector3 randomVector = Random.insideUnitSphere * rangeToMake;
			//Vector3 place = new Vector3(randomVector.x, 1f, randomVector.z);
			//Instantiate(tree, place, Quaternion.identity);

			Vector3 randomspot = new Vector3(Random.Range(collider.bounds.min.x, collider.bounds.max.x),
			                                 0f,
			                                 Random.Range(collider.bounds.min.z, collider.bounds.max.z));

			GameObject newthing = Instantiate(thing,randomspot,Quaternion.identity) as GameObject;
		
			newthing.transform.Rotate(0f, Random.Range(0f,360f), 0f);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
