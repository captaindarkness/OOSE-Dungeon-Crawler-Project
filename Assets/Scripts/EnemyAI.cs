using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	Transform target;
	public Transform myTransform;
	public float moveSpeed = 0.5f;
	public float rotationSpeed = 3.0f;
	bool Detect;
	public float radiusAI = 10;

		
	// Use this for initialization
	void Start () {
		//Set target to find a GameObject with the Tag Player which is set in unity
		target = GameObject.FindWithTag ("Player").transform;
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		//If Detect is true the Enemy object will rotate its front towards the Player and move towards the Player object by trying to match its position 
		if (Detect) {
			myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (target.position - myTransform.position), rotationSpeed * Time.deltaTime);

			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
		}
		//Keeps running the detectArea function
		detectArea ();
		
	}

	void detectArea(){
		//Distance is used to define a circle around the Enemy
		float distance = Vector3.Distance (target.transform.position, transform.position);
		//If the Player is within 5 units of the Enemy it will turn detect on, if above 5 units it will turn off
		if (distance < radiusAI) {
			Detect = true;
		} 
		else if(distance > radiusAI) {
			Detect = false;
		}
	}
}
