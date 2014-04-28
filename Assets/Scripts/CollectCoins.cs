using UnityEngine;
using System.Collections;

public class CollectCoins : MonoBehaviour {
	public float coins;
	public AudioSource coinSound;
	//This is activated when the player collides with the object.
	void  OnTriggerEnter (  Collider other   ){
		//Checks wether the object is the correct one.
		if (other.gameObject.name == "coin") {
			//Adds 1 to the coin counter (the GUI is updated).
			coins += 1;
			//The obejct is destroyed.
			Destroy(other.gameObject);
			//The specific sound will play.
			coinSound.Play();
			Debug.Log ("Hit");
		}
	}
	
	void  OnGUI () {
		//GUI for the amount of gold collected.
		GUI.Label ( new Rect(20, 20, 200, 40), coins + "");
		
	}
}