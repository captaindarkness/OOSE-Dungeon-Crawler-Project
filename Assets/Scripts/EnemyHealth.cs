using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int maxHealth = 100;
	public int curHealth = 100;

	// Update is called once per frame
	void Update () {
		AddjustCurrentHealth(0);
	}

	public void AddjustCurrentHealth(int addj){
		curHealth += addj;
		//This will only load if you click the boss because the boss is the only enemy with 60 health
		if(curHealth <= 0 && maxHealth == 60){
			Application.LoadLevel("EndMenu");
		}
		//Will destroy the object when its health reaches 0 or less
		if(curHealth <= 0){
			Destroy (gameObject);
		}
		//will keep current health to the same as max health
		if(curHealth > maxHealth){
			curHealth = maxHealth;
		}
		//this will make it so that enemies can have below 0 so it doesn't get destroyed on start up
		if(maxHealth < 1){
			maxHealth = 1;
		}
	}
}
