using UnityEngine;
using System.Collections;

public class CollectHealth : MonoBehaviour {

	public Health health;
	public AudioSource healthSound;
	//This is activated when the player collides with the object.
	void  OnTriggerEnter (  Collider other   ){
		//Checks wether the object is the correct one.
		if (other.gameObject.name == "healthup") {
			//Adds 20 health to the player's health.
			health.modifyHealth(+20);
			//The specific sound will play.
			healthSound.Play();
			//The obejct is destroyed.
			Destroy(other.gameObject);
		}
	}
}
