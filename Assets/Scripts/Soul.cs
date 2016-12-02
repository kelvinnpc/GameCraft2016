﻿using UnityEngine;
using System.Collections;

public class Soul : MonoBehaviour {

	public float speed;
	Rigidbody2D rgbody;
	// Use this for initialization
	void Start () {
		rgbody = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate () {

		Vector3 velocity = Vector3.zero;

		if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
			velocity += Vector3.left * speed;
			transform.right = Vector3.left;
		}
		else if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) {
			velocity += Vector3.up * speed;
			transform.right = Vector3.up;
		}
		else if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
			velocity += Vector3.right * speed;
			transform.right = Vector3.right;
		}
		else if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) {
			velocity += Vector3.down * speed;
			transform.right = Vector3.down;
		}
		rgbody.velocity = velocity;

	}
}
