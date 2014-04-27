using UnityEngine;
using System.Collections;

public class SwordSwing : MonoBehaviour {

	public float gizmoSize = 0.75f;
	public Color gizmoColor = Color.yellow;
	public float smooth = 2.0f;
	public float attackTimer;
	public float coolDown;

	void Start (){
		attackTimer = 0;
		coolDown = 2.0f;
	}

	void OnDrawGizmos(){
		Gizmos.color = gizmoColor;
		Gizmos.DrawWireSphere (transform.position, gizmoSize);
	}

	void Update(){

		if(attackTimer > 0){
			attackTimer -= Time.deltaTime;
		}
		
		if(attackTimer < 0){
			attackTimer = 0;
		}


		if (Input.GetKeyUp (KeyCode.Space)) {
			Quaternion target = Quaternion.Euler (0, 60, 0);
			transform.rotation = Quaternion.Slerp (transform.rotation, target, smooth);
		}
		if(Input.GetKeyDown (KeyCode.Space)){
			if(attackTimer == 0){
			attackTimer = coolDown;
			Quaternion target = Quaternion.Euler (0, 90, 0);
			transform.rotation = Quaternion.Slerp (transform.rotation, target, smooth);
		}
		
	}
}
}
