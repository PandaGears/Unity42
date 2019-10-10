using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildings : MonoBehaviour {

	public float buildingMaxHP;
	public float buildingsHP;
	public bool isDead = false;
	public Sprite deadSprite;

	public GameObject townHall;

	public AudioClip audio;

	public AudioClip damage;

	void Start () {
		if (tag == "human_town")
			townHall = GameObject.FindGameObjectWithTag ("human_townhall");
		else if (tag == "orc_town")
			townHall = GameObject.FindGameObjectWithTag ("orc_townhall");
		buildingMaxHP = buildingsHP;
	}

	void Update () {
		if (buildingsHP < 0)
			buildingsHP = 0;
		if (buildingsHP == 0 && !isDead) {
			isDead = true;
			GetComponent<AudioSource>().Play();
			increaseSpawnTime ();
			gameObject.GetComponent<Collider2D> ().enabled = false;
			GetComponent<SpriteRenderer> ().sprite = deadSprite;

			if (transform.tag == "human_townhall") {
				Debug.Log ("The Horde wins.");
				Time.timeScale = 0;
			} else if (transform.tag == "orc_townhall") {
				Debug.Log ("The Alliance wins.");
				Time.timeScale = 0;
			}
		}
	}

	void increaseSpawnTime() {
		townHall.GetComponent<townHallSpawner> ().spawnTime += 2.5f;
	}
}
