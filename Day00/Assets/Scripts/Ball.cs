using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	static public int Speed = 0;
	static public bool direct = true;
	static public bool end = false;

	void Start () {
	
	}
	void Update () {
		if (Club.Force > 0 && Input.GetKeyUp (KeyCode.Space)) {
	
			Speed = Club.Force;
			direct = true;
			Club.Force = 0;
		}
		if (Speed > 0) {
			if (transform.position.y >= 20) {
				direct = false;
			}
			else if (transform.position.y <= -13.5F) {
				direct = true;
			}
			if (direct == true) {
				transform.Translate(0, 0.4F, 0);
				Speed -= 1;
			}
			else {
				transform.Translate(0, -0.4F, 0);
				Speed -= 1;
			}
		}
		if (Speed < 5 && Speed >= 0) {
			if (transform.position.y > 17 && transform.position.y < 18){
				GameObject.Destroy(gameObject);
				end = true;
				if (Club.Score <= 0)
					Debug.Log ("Score:" + Club.Score);
				else
					Debug.Log ("Score:" + Club.Score);

			}
		}
	}
}
