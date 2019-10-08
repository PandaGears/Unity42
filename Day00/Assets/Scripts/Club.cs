using UnityEngine;
using System.Collections;

public class Club : MonoBehaviour {
	
	static public int Score = -15;
	static public int Force = 0;
	static public bool keyPressed = false;
	static public bool BallBouncing = false;
	static public float Defautclub = -0.5F;
	public GameObject BallsImage;

	void Start () {
		
	}

	void Update () {
		if (Ball.end == true)
			GameObject.Destroy(gameObject);

		if (BallBouncing == true && Ball.Speed == 0 && BallsImage != null) {
			if (transform.position.y != (BallsImage.transform.position.y - 0.2)) {
				transform.position = new Vector3(-1, (BallsImage.transform.position.y - 0.2F), 0);
				Defautclub = BallsImage.transform.position.y - 0.2F;
				BallBouncing = false;
			}
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			keyPressed = true;
			if (transform.position.y > -11)
				transform.Translate(0F, -0.02F, 0F);
			
		}

		else if (Input.GetKeyUp (KeyCode.Space)) {
			keyPressed = false;
			if (transform.position.y < Defautclub) {
				while (transform.position.y < Defautclub)
					transform.Translate(0F, +0.02F, 0F);
				Score += 5;
				Debug.Log ("score: " + Score);
				BallBouncing = true;
			}
		}

		if (keyPressed == true) {

			if (transform.position.y > -2.15)
			{
				transform.Translate(0F, -0.02F, 0F);
				Force += 1;
			}
		}
	}
}
