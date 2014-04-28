﻿using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	public float playerSpeed = 5.0f;
	public static bool alive;
	public float smooth = 2.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
//		if(Input.GetButtonDown("Jump") && transform.position.y < 1){//Jump with limit on
//			rigidbody.AddForce(new Vector3(0, 400.0f, 0));
//		}
		//If the Boolean alive is True meaning that the player has health above 0, Using built-in features (.right .forward) which are Inputs that are already defined
		//and assigned in Unity.
		if (alive) {
			transform.Translate (Vector3.right * Input.GetAxis ("Horizontal") * playerSpeed * Time.deltaTime); // left / right
			transform.Translate (Vector3.forward * Input.GetAxis ("Vertical") * playerSpeed * Time.deltaTime); // forward / backwards
		}
	}
}
