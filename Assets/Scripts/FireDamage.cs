using UnityEngine;
using System.Collections;

public class FireDamage : MonoBehaviour {

	public Health health;
	
	void  OnTriggerStay (  Collider other   ){
		if (other.gameObject.name == "fire") {
			health.modifyHealth(-1);
		}
	}
}
