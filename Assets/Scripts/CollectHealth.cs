using UnityEngine;
using System.Collections;

public class CollectHealth : MonoBehaviour {

	public Health health;

	void  OnTriggerEnter (  Collider other   ){
		if (other.gameObject.name == "healthup") {
			health.modifyHealth(+5);
			Destroy(other.gameObject);
		}
	}
}
