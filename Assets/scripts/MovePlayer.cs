using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {

	CharacterController controller;
	Vector3 velocity;
	Vector3 moveVector;

	public float gravity = 9.8f;
	public float speed = 1f;
	public float sidespeed = 10f;
	public float sideacceleration = 10f;
	public float forwardacceleration = 10f;

	int lastKeyPress = 1;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		velocity = controller.velocity;
		moveVector = Vector3.zero;

		if (Input.GetKeyDown(KeyCode.Z) && lastKeyPress == 1 || Input.GetKeyDown(KeyCode.X) && lastKeyPress == 0){
			if (lastKeyPress == 1) lastKeyPress = 0;
			else lastKeyPress = 1;

			moveVector += transform.forward;
		}

		if (Mathf.Abs(velocity.z) > 1f){
			if (Input.GetKeyDown(KeyCode.LeftArrow))
				moveVector -= transform.right;
			if (Input.GetKeyDown(KeyCode.RightArrow))
				moveVector += transform.right;
		}

		if (controller.isGrounded){
			velocity.x = Mathf.Lerp(velocity.x, moveVector.normalized.x*sidespeed, Time.deltaTime * sideacceleration);
			velocity.z = Mathf.Lerp(velocity.z, moveVector.normalized.z*speed, Time.deltaTime * forwardacceleration);
		}

		if(!controller.isGrounded)
			velocity.y -= gravity * Time.deltaTime;
		controller.Move(velocity * Time.deltaTime);

	}

	void OnControllerColliderHit(ControllerColliderHit hit){

		if (hit.gameObject.tag == "Obstacle"){
			Debug.Log("OW");
		}
	}
	


	
}
