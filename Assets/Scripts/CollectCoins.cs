using UnityEngine;
using System.Collections;

public class CollectCoins : MonoBehaviour {
	private float screenHeight;
	private float screenWidth;
	public float coins;
	public AudioSource coinSound;

	void Start(){
		screenHeight = Screen.height;
		screenWidth = Screen.width;
	}

	void Awake(){
		DontDestroyOnLoad(gameObject);
	}

	//This is activated when the player collides with the object.
	void  OnTriggerEnter (  Collider other   ){
		//Checks wether the object is the correct one.
		if (other.gameObject.name == "coin") {
			//Adds 1 to the coin counter (the GUI is updated).
			coins += 1;
			//The object is destroyed.
			Destroy(other.gameObject);
			//The specific sound will play.
			coinSound.Play();
			Debug.Log ("Hit");
		}
	}
	
	void  OnGUI () {
		//GUI for the amount of gold collected.
		GUI.Label(new Rect(screenWidth/15.0f,screenHeight/15.0f,400,40),"<color=white><size=35>"+coins+"</size></color>");
		
	}
}