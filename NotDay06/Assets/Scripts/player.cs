using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player : MonoBehaviour {

	public float invisible = 0;
	private bool isTriggered = false;
	private bool isRunning = false;

	public float speed;

	public AudioClip getKeySound;
	public AudioClip musicNormal;
	public AudioClip musicPanic;
	public GameObject foot;

	private enum currentAudioEnum {normal, panic};
	private currentAudioEnum currentAudio = currentAudioEnum.normal;
	private enum currentWalkSpeedEnum {stay, normal, speed};
	private currentWalkSpeedEnum currentWalkSpeed = currentWalkSpeedEnum.stay;

	public Scrollbar bar;

	private bool haskey = false;

	// Use this for initialization
	void Start () {
	}

	public bool playerHasKey() {
		return haskey;
	}

	public void removeKey() {
		haskey = false;
	}
		
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Papers") {
			GameManager.gm.setMessage ("Congratulations Fisher, once again you helped us a lot.");
			StartCoroutine ("displayMessageBeforeRestart");
		}
	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject.tag == "key1" && !haskey) {
			AudioSource audio = other.GetComponent<AudioSource> ();
			audio.Play ();
			StartCoroutine (waitBeforeDelete (other.gameObject));
			haskey = true;
			GameManager.gm.setMessage ("You got the key ! Now you have to find the hidden papers.");
		} else if (other.gameObject.tag == "light" || other.gameObject.tag == "laser" ) {
			playerSpotted (.5f);
		}

	}

	void OnTriggerExit(Collider other) {
		isTriggered = false;
	}

	void Update () {

		if (invisible >= 75 && currentAudio != currentAudioEnum.panic) {
			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip = musicPanic;
			audio.Play ();
			currentAudio = currentAudioEnum.panic;
		} else if (invisible < 75 && currentAudio != currentAudioEnum.normal) {
			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip = musicNormal;
			audio.Play ();
			currentAudio = currentAudioEnum.normal;
		}

		if (invisible >= 100) {
			GameManager.gm.setMessage ("You have been spotted, RIP in Pepperonis.");
			StartCoroutine ("displayMessageBeforeRestart");
		}


	IEnumerator displayMessageBeforeRestart() {
		yield return new WaitForSeconds (4);
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);

	}
}

	public void playerSpotted(float value) {
		invisible += value;

	}

	IEnumerator waitBeforeDelete(GameObject go) {
		yield return new WaitForSeconds (.2f);
		Destroy (go);

	}
}
