using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public float timer = 10f;

	public float countdownspeed = 1f;

	public float incrementamount = 1f;

	public TextMesh timertext;

	bool isStopped = false;

	// Update is called once per frame
	void Update () {

		if (!isStopped) timer -= Time.deltaTime * countdownspeed;

		timertext.text = timer.ToString("00.00");

	}

	public void FreezeTimer(){
		isStopped = true;
	}

	public void MakeScoreRed(){
		timertext.color = Color.red;
	}

	public void IncrementScore(){
		timer += incrementamount;
	}
}
