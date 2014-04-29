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

		if(curHealth <= 0 && maxHealth == 60){
			Application.LoadLevel("EndMenu");
		}

		if(curHealth <= 0){
			Destroy (gameObject);
		}

		if(curHealth > maxHealth){
			curHealth = maxHealth;
		}

		if(maxHealth < 1){
			maxHealth = 1;
		}
	}
}
