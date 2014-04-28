using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerAttack : MonoBehaviour {
	
	Transform target;
	//List of enemies.
	public List<GameObject> targets;
	public float attackTimer;
	public float coolDown;

	void Start (){
		//The timer starts at 0 and will be updated later.
		attackTimer = 0;
		//The cool down is set to 2
		coolDown = 2.0f;
		//The list is set to contain any object tagged with "enemy".
		GameObject[] enemyTargets = GameObject.FindGameObjectsWithTag("enemy");
		//If there are enemies in the world they will be pushed to the targets array
		if (enemyTargets != null)
		{
			foreach(GameObject go in enemyTargets)
			{
				targets.Add(go);//pushing targets in array
			}
		}
	}
	// Update is called once per frame
	void Update(){
		//Target for the player is set to objects tagged with "enemy"
		target = GameObject.FindWithTag ("enemy").transform;
		//If the timer is above 0, the timer will go down.
		if(attackTimer > 0){
			attackTimer -= Time.deltaTime;
		}
		//If attack timer should go below 0 the timer will reset to 0.
		if(attackTimer < 0){
			attackTimer = 0;
		}

		//The player will attack when pressing down the SPACE key.
		if(Input.GetKeyDown (KeyCode.Space)){
			//If the attack timer is 0 the attack will activate.
			if(attackTimer == 0){
				//The attack function is called
				Attack();
				//After attack, the attack timer is set equal to the cool down.
				attackTimer = coolDown;
			}
		}

	}
	//Function for attack.
	private void Attack(){
		foreach(GameObject target in targets){
			//If there is a target damage will be dealt.
			if(target != null){
				//Variable for distance between player and enemy.
				float distance = Vector3.Distance (target.transform.position, transform.position);
				//If the distance is below 2, the player will deal damage.
				if(distance < 2){
					//Gets the component for the enemy's health.
					EnemyHealth eh = (EnemyHealth)target.GetComponent("EnemyHealth");
					//Enemy looses 10 health.
					eh.AddjustCurrentHealth(-10);
				}
			}
		}
	}

}
