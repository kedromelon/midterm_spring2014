using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {

	CharacterController controller;
	Vector3 velocity;
	Vector3 moveVector;

	public float gravity = 9.8f;
	public float speed = 1f;
	float sidespeed;
	public float sidespeeddivider = 4f;
	public float sideacceleration = 10f;
	public float forwardacceleration = 10f;

	public ScoreManager scoremanager;

	public AudioClip hitsound;

	public GameObject plus;

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

		if (Input.GetKeyDown(KeyCode.J) && !Input.GetKeyDown(KeyCode.K) && lastKeyPress == 1 
		    || Input.GetKeyDown(KeyCode.K) && !Input.GetKeyDown(KeyCode.J) && lastKeyPress == 0){
			if (lastKeyPress == 1){
				playerAnimation.Play("rightlegforward");
				lastKeyPress = 0;
			}
			else{
				playerAnimation.Play("leftlegforward");
				lastKeyPress = 1;
			}

			moveVector += transform.forward;
		}

		if (velocity.z != 0f){
			if (Input.GetKey(KeyCode.A))
				moveVector -= transform.right;
			if (Input.GetKey(KeyCode.D))
				moveVector += transform.right;
			sidespeed = velocity.z/sidespeeddivider;

		}

		if (controller.isGrounded){
			velocity.x = Mathf.Lerp(velocity.x, moveVector.normalized.x*sidespeed, .03f * sideacceleration);
			velocity.z = Mathf.Lerp(velocity.z, moveVector.normalized.z*speed, .03f * forwardacceleration);
		}

		if(!controller.isGrounded)
			velocity.y -= gravity;
		controller.Move(velocity * Time.deltaTime);

		if (velocity.magnitude < .1f)
			playerAnimation.Play("idle");

		if (scoremanager.timer <= 0f){
			scoremanager.timer = 0f;
			Lose();
		}
	}

	void OnControllerColliderHit(ControllerColliderHit c){
		if (c.gameObject.tag == "Obstacle"){
			if (GetComponentInChildren<PowerupTrigger>().powerups > 0){
				GetComponentInChildren<PowerupTrigger>().DestroyObstacle(c.collider);
			}else{
				GetComponent<MovePlayer>().Lose();
			}

		}
	}

	void OnTriggerEnter(Collider c){
		if (c.gameObject.name == "Igloo") StartCoroutine("EndAfterSeconds");
	}

	void OnTriggerExit(Collider c){
		if (c.tag == "Score"){
			GameObject newplus = Instantiate(plus, transform.position + transform.up, Quaternion.identity) as GameObject;
			newplus.transform.parent = transform;
			scoremanager.IncrementScore();
		} 
	}

	IEnumerator EndAfterSeconds(){
		GetComponent<MovePlayer>().enabled = false;
		yield return new WaitForSeconds(.5f);
		ScreenShake2D.Shake(0f,0f);
		Application.LoadLevel(Application.loadedLevel);
	}

	public void Lose(){
		scoremanager.FreezeTimer();
		scoremanager.MakeScoreRed();
		ScreenShake2D.Shake(.25f,.5f);
		GetComponent<AudioSource>().PlayOneShot(hitsound);
		GetComponent<AudioSource>().Play();
		StartCoroutine("EndAfterSeconds");
	}
	
}
