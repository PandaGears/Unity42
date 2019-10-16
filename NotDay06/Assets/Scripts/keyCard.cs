using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyCard : MonoBehaviour {


	void Start () {
		StartCoroutine ("rotate");
	}

	void Update () {
		
	}

	IEnumerator rotate() {
		while (true) {
			transform.Rotate (Vector3.up);
			yield return new WaitForSeconds(0.01f);
		}
	}
}
