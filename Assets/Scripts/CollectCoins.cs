using UnityEngine;
using System.Collections;

public class CollectCoins : MonoBehaviour {
	public float coins;
	
	void  OnTriggerEnter (  Collider other   ){
		if (other.gameObject.name == "coin") {
			coins += 1;
			Destroy(other.gameObject);
			Debug.Log ("Hit");
		}
	}
	
	void  OnGUI () {
		
		GUI.Label ( new Rect(20, 20, 200, 40), coins + "");
		
	}
}