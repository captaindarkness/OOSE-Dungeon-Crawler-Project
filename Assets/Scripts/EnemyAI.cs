using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	Transform target;
	public Transform myTransform;
	public float moveSpeed = 0.5f;
	public float rotationSpeed = 3.0f;
	bool Detect;


	// Use this for initialization
	void Start () {
		target = GameObject.FindWithTag ("Player").transform;
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (Detect) {
			myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (target.position - myTransform.position), rotationSpeed * Time.deltaTime);

			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
		}
		detectArea ();
		
	}

	void detectArea(){
		float distance = Vector3.Distance (target.transform.position, transform.position);
		if (distance < 5) {
			Detect = true;
		} else if(distance > 5) {
			Detect = false;
		}
	}
}
