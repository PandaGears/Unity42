using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public player player;
	public static GameManager gm;
	public Text message;

	void Start () {
		if (gm == null)
			gm = this;
		message.GetComponent<Animator> ().SetTrigger ("showText");
	}

	void Update () {
		
	}

	public void cameraSpotPlayer() {
		player.playerSpotted (20);
	}

	public void setMessage(string msg) {
		message.text = msg;
		message.GetComponent<Animator> ().SetTrigger ("showText");
	}
}
