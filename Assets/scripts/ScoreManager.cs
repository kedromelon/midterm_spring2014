using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public float timer = 10f;

	public TextMesh timertext;

	// Update is called once per frame
	void Update () {
		timer = Mathf.Lerp(timer, 0, Time.deltaTime * .1f);
		timertext.text = timer.ToString("00.00");
	}
}
