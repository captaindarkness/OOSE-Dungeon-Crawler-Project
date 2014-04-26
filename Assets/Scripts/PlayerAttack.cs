﻿using UnityEngine;

using System.Collections;

public class PlayerAttack : MonoBehaviour {
	
	public GameObject target;
	public float attackTimer;
	public float coolDown;

	void Start (){
		attackTimer = 0;
		coolDown = 2.0f;
	}

	void Update(){
		if(attackTimer > 0){
			attackTimer -= Time.deltaTime;
		}

		if(attackTimer < 0){
			attackTimer = 0;
		}

		//the player will attack when pressing SPACE
		if(Input.GetKeyUp (KeyCode.Space)){
			if(attackTimer == 0){
			Attack();
			attackTimer = coolDown;
			}
		}

	}

	private void Attack(){

		float distance = Vector3.Distance (target.transform.position, transform.position);

//		float dir = (target.transform.position - transform.Transform.position).normalized;
//
//		float direction = Vector3.Dot (dir, transform.forward);

		if(distance < 2){
			EnemyHealth eh = (EnemyHealth)target.GetComponent("EnemyHealth");
			eh.AddjustCurrentHealth(-10);
		}
	}

}