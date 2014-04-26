using UnityEngine;
using System.Collections;

public class DetectionArea : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.name == "Player"){
			EnemyAI.Detect = true;
		}
	}
	void OnTriggerExit(Collider other){
		EnemyAI.Detect = false;
	}
}
