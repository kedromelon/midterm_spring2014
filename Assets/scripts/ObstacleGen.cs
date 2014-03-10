using UnityEngine;
using System.Collections;

public class ObstacleGen : MonoBehaviour {

	public int thingsToMake = 200;

	public GameObject thing;
	public GameObject thing2;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < thingsToMake; i++){

			GameObject thingToSpawn;

			if (Random.Range(0f,1f) < .25f){
				thingToSpawn = thing2;
			}else{
				thingToSpawn = thing;
			}

			Vector3 randomspot = new Vector3(Random.Range(collider.bounds.min.x, collider.bounds.max.x),
			                                 transform.position.y,
			                                 Random.Range(collider.bounds.min.z, collider.bounds.max.z));

			GameObject newthing = Instantiate(thingToSpawn,randomspot,Quaternion.identity) as GameObject;
		
			newthing.transform.Rotate(0f, Random.Range(0f,360f), 0f);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
