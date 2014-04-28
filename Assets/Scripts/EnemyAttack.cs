using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {
	public float attackTimer;
	public float coolDown;
	public Transform target;
	public Health health;
	public float attackArea = 2;
	public int enemyDamage = 5;
	public AudioSource enemyAttack;
	// Use this for initialization
	void Start () {
		attackTimer = 0;
		coolDown = 2.0f;
	}
	
	// Update is called once per frame
	void Update () {
		//If the timer is above 0, the timer will go down.
		if(attackTimer > 0){
			attackTimer -= Time.deltaTime;
		}
		//If attack timer should go below 0 the timer will reset to 0.
		if(attackTimer < 0){
			attackTimer = 0;
		}
		//If attackTimer is equal to 0 it will run the Attack function and set attackTimer equal to coolDown
		if(attackTimer == 0){
			Attack();
			attackTimer = coolDown;
		}
	}
	private void Attack(){
		//This is used to define a area around the Enemy Object
		float distance = Vector3.Distance (target.transform.position, transform.position);
		//If the player is within 2 the player will lose 5 health every 2 seconds
		if(distance < attackArea){
			health.modifyHealth(-enemyDamage);
			enemyAttack.Play ();
		}
	}
}
