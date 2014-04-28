using UnityEngine;
using System.Collections;

public class SwordSwing : MonoBehaviour {

	public float gizmoSize = 0.75f;
	public Color gizmoColor = Color.yellow;
	public float smooth = 2.0f;
	public float attackTimer;
	public float coolDown;
	public float swordPos = 60.0f;
	public float newSwordPos;
	bool faceUp;
	bool faceDown;
	bool faceLeft;
	bool faceRight;
	public AudioSource swing;

	void Start (){
		attackTimer = 0;
		coolDown = 1.0f;
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
		//These are used to Rotate the Sword so it faces the way you are walking
		if(Input.GetKeyDown(KeyCode.W) && !faceUp || Input.GetKeyDown(KeyCode.UpArrow) && !faceUp){
			newSwordPos = swordPos - 90.0f;
			transform.rotation = Quaternion.Euler(0,newSwordPos,0);
			faceUp = true;
			faceDown = false;
			faceLeft = false;
			faceRight = false;
			//Debug.Log("Facing up");
		}
		if(Input.GetKeyDown(KeyCode.S) && !faceDown || Input.GetKeyDown(KeyCode.DownArrow) && !faceDown){
			newSwordPos = swordPos + 90.0f;
			transform.rotation = Quaternion.Euler(0,newSwordPos,0);
			faceUp = false;
			faceDown = true;
			faceLeft = false;
			faceRight = false;
			//Debug.Log("Facing down");
		}
		if(Input.GetKeyDown(KeyCode.A) && !faceLeft || Input.GetKeyDown(KeyCode.LeftArrow) && !faceLeft){
			newSwordPos = swordPos + 180.0f;
			transform.rotation = Quaternion.Euler(0,newSwordPos,0);
			faceUp = false;
			faceDown = false;
			faceLeft = true;
			faceRight = false;
			//Debug.Log("Facing left");
		}
		if(Input.GetKeyDown(KeyCode.D) && !faceRight || Input.GetKeyDown(KeyCode.RightArrow) && !faceRight){
			newSwordPos = swordPos;
			transform.rotation = Quaternion.Euler(0,newSwordPos,0);
			faceUp = false;
			faceDown = false;
			faceLeft = false;
			faceRight = true;
			//Debug.Log("Facing right");
		}

		if (Input.GetKeyUp (KeyCode.Space)) {
			Quaternion target = Quaternion.Euler (0, newSwordPos, 0);
			transform.rotation = Quaternion.Slerp (transform.rotation, target, smooth);
		}
		if(Input.GetKeyDown (KeyCode.Space)){
			if(attackTimer == 0){
				attackTimer = coolDown;
				Quaternion target = Quaternion.Euler (0, newSwordPos + 60, 0);
				transform.rotation = Quaternion.Slerp (transform.rotation, target, smooth);
				swing.Play ();
			}
		}
	}
}
