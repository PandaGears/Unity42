using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class townhall : MonoBehaviour {

	public float spawnTime = 10;
	public GameObject unit;

	private float timer = 0;
	void Start () {
		
	}
	void Update () {
		if (timer >= spawnTime) {
			timer = 0;
			GameObject.Instantiate(unit, new Vector3(transform.position.x, transform.position.y - 1, 0), Quaternion.identity);
		}
		timer += Time.deltaTime;
	}
}
