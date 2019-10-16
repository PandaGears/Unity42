using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
		
	public static GameManager gm;

	void Start () {
		if (gm == null)
			gm = this;
		Cursor.visible = false;
	}

	void Update () {
		
	}

	public void playDead() {
		GetComponent<AudioSource> ().Play ();
	}
}
