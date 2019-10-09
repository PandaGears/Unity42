using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour {
	public static playerScript_ex00 controller;
	private GameObject characters;

	void Start () {

		characters = GameObject.FindGameObjectWithTag("Thomas");

	}

	void Update () {
		if (playerScript_ex00.GetController == 0) {

			if (tag == "camera1")
				characters = GameObject.FindGameObjectWithTag ("Claire");
			else if (tag == "camera2")
				characters = GameObject.FindGameObjectWithTag ("John");
			else
				characters = GameObject.FindGameObjectWithTag ("Thomas");
		}
		else if (playerScript_ex00.GetController == 1) {

			if (tag == "camera1")
				characters = GameObject.FindGameObjectWithTag ("Claire");
			else if (tag == "camera2")
				characters = GameObject.FindGameObjectWithTag ("Thomas");
			else
				characters = GameObject.FindGameObjectWithTag ("John");
		}
		else {

			if (tag == "camera1")
				characters = GameObject.FindGameObjectWithTag ("Thomas");
			else if (tag == "camera2")
				characters = GameObject.FindGameObjectWithTag ("John");
			else
				characters = GameObject.FindGameObjectWithTag ("Claire");
		}
		if (characters != null) {
			transform.position = characters.transform.position;
			transform.Translate (0, 0, -10);
		}
	}
}