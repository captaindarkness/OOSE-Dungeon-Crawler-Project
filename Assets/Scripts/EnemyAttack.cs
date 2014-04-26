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
		
		float distance = Vector3.Distance (target.transform.position, transform.position);
		
		//		float dir = (target.transform.position - transform.Transform.position).normalized;
		//
		//		float direction = Vector3.Dot (dir, transform.forward);
		
		if(distance < 2){
//			Health hp = (Health)target.GetComponent("Health");
//			hp.modifyHealth(-3);
			health.modifyHealth(-3);
		}
	}
}
