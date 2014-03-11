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

	public ScoreManager scoremanager;

	Animation playerAnimation;

	int lastKeyPress = 1;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		playerAnimation = GetComponentInChildren<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
		velocity = controller.velocity;
		moveVector = Vector3.zero;

		if (Input.GetKeyDown(KeyCode.J) && lastKeyPress == 1 || Input.GetKeyDown(KeyCode.K) && lastKeyPress == 0){
			if (lastKeyPress == 1){
				playerAnimation.Play("rightlegforward");
				lastKeyPress = 0;
			}
			else{
				playerAnimation.Play("leftlegforward");
				lastKeyPress = 1;
			}

			if (Input.GetKey(KeyCode.A))
				moveVector -= transform.right;
			if (Input.GetKey(KeyCode.D))
				moveVector += transform.right;

			moveVector += transform.forward;
		}

		if (controller.isGrounded){
			velocity.x = Mathf.Lerp(velocity.x, moveVector.normalized.x*sidespeed, Time.deltaTime * sideacceleration);
			velocity.z = Mathf.Lerp(velocity.z, moveVector.normalized.z*speed, Time.deltaTime * forwardacceleration);
		}

		if(!controller.isGrounded)
			velocity.y -= gravity * Time.deltaTime;
		controller.Move(velocity * Time.deltaTime);

		if (velocity.magnitude < .1f)
			playerAnimation.Play("idle");

		if (scoremanager.timer <= 0f){
			scoremanager.timer = 0f;
			Lose();
		}

	}

	void OnTriggerExit(Collider c){
		if (c.tag == "Score") scoremanager.IncrementScore();
	}

	void OnControllerColliderHit(ControllerColliderHit c){
		if (c.gameObject.tag == "Obstacle"){
			Lose();
		}
	}
	
	IEnumerator EndAfterSeconds(){
		GetComponent<MovePlayer>().enabled = false;
		yield return new WaitForSeconds(.5f);
		ScreenShake2D.Shake(0f,0f);
		Application.LoadLevel(Application.loadedLevel);
	}

	void Lose(){
		scoremanager.FreezeTimer();
		scoremanager.MakeScoreRed();
		ScreenShake2D.Shake(.25f,.5f);
		GetComponent<AudioSource>().Play();
		StartCoroutine("EndAfterSeconds");
	}
	
}
