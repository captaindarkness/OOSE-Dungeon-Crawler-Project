using UnityEngine;
using System.Collections;

public class CollectHealth : MonoBehaviour {

	public Health health;
	public AudioSource healthSound;

	void  OnTriggerEnter (  Collider other   ){
		if (other.gameObject.name == "healthup") {
			health.modifyHealth(+5);
			healthSound.Play();
			Destroy(other.gameObject);
		}
	}
}
