using UnityEngine;
using System.Collections;

public class FireDamage : MonoBehaviour {

	public Health health;

	//As long as the player is inside the collider of the fire, the player will take constant damage.
	void  OnTriggerStay (  Collider other   ){
		//Checks wether the object is the correct one.
		if (other.gameObject.name == "fire") {
			//The damage will take 1 damage.
			health.modifyHealth(-1);
		}
	}
}
