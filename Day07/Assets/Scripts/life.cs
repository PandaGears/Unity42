using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class life : MonoBehaviour {

	public float hp = 100;		

	void Start () {								
		
	}

	void Update () {
		if (hp <= 0 && !GetComponent<AudioSource>().isPlaying) {
			GameManager.gm.playDead ();
			if (gameObject.transform.tag != "player")
				Destroy (gameObject);
			else
				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
	}

}
