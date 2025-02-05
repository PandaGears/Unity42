﻿using UnityEngine;
using System.Collections;

public class Balloon : MonoBehaviour
{
public static float timer = 0;
public int breath = 100;
private bool live = true;
// Use this for initialization
void Start () {
}
// Update is called once per frame
void Update () {
timer += Time.deltaTime;
if (Input.GetKeyDown(KeyCode.Space) && live && breath >= 10) {
transform.localScale += new Vector3(0.2F, 0.2F, 0.2F);
breath = breath - 15;
}  else if (transform.localScale.x > 0 && live) {
transform.localScale -= new Vector3(0.02F, 0.02F, 0.02F);
}
if (live && (transform.localScale.x >= 5 || transform.localScale.x <= 0 || Mathf.RoundToInt (timer) == 20)) {
transform.localScale = new Vector3 (0, 0, 0);
Debug.Log("Balloon life time: " + Mathf.RoundToInt (timer) + "s");
live = false;
}
if (live == false) {
GameObject.Destroy(gameObject);
}
breath = breath + 5;
}
}
