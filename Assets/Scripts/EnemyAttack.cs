using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {
	public float attackTimer;
	public float coolDown;
	public Transform target;
	public Health health;
	// Use this for initialization
	void Start () {
		attackTimer = 0;
		coolDown = 2.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(attackTimer > 0){
			attackTimer -= Time.deltaTime;
		}
		
		if(attackTimer < 0){
			attackTimer = 0;
		}
		
		if(attackTimer == 0){
			Attack();
			attackTimer = coolDown;
		}
	}
	private void Attack(){
		//This is used to define a area around the Enemy Object
		float distance = Vector3.Distance (target.transform.position, transform.position);
		//If the player is within 2 the player will lose 5 health every 2 seconds
		if(distance < 2){
			health.modifyHealth(-5);
		}
	}
}
