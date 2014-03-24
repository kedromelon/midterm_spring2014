using UnityEngine;
using System.Collections;

public class ObstacleGen : MonoBehaviour {

	public int thingsToMake = 200;

	public int powerupsToMake = 20;

	public GameObject thing;
	public GameObject thing2;
	public GameObject powerup;

	public GameObject scoretrigger;

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

			if (scoretrigger != null)
				Instantiate(scoretrigger, new Vector3(transform.position.x, transform.position.y, randomspot.z), Quaternion.identity);
		
			newthing.transform.Rotate(0f, Random.Range(0f,360f), 0f);
		}

		if (powerup != null){
			for (int i = 0; i < powerupsToMake; i++){
				Vector3 randomspot = new Vector3(Random.Range(collider.bounds.min.x, collider.bounds.max.x),
				                                 transform.position.y + 1f,
				                                 Random.Range(collider.bounds.min.z, collider.bounds.max.z));
				Instantiate(powerup,randomspot,Quaternion.identity);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
