using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orc : MonoBehaviour {

	public float maxHP;
	public float orcHP;
	public bool isDead = false;
	public Sprite deadSprite;
	void Start () {
		maxHP = orcHP;
	}
	void Update () {
		if (orcHP <= 0 && !isDead) {
			isDead = true;
			gameObject.GetComponent<Collider2D> ().enabled = false;
			GetComponent<Animator>().SetTrigger("die");
		}
		if(isDead)
			GetComponent<AudioSource>().Play();
	}
}
