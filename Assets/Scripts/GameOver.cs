using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	private float screenHeight;
	private float screenWidth;
	private float buttonHeight;
	private float buttonWidth;
	// Use this for initialization
	void Start () {
		screenHeight = Screen.height;
		screenWidth = Screen.width;

		buttonHeight = 30.0f;
		buttonWidth = 100.0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//GUI for 'Game Over'.
	void OnGUI(){

		GUI.Label(new Rect(screenWidth/2.5f, screenHeight/2.5f, 400, 100),"<color=white><size=50>"+"Game Over"+"</size></color>");
		GUI.Label(new Rect(screenWidth/2.5f, screenHeight/2.2f, 400, 100),"<color=red><size=35>"+"You Died"+"</size></color>");

		if(GUI.Button (new Rect(screenWidth/2.1f, screenHeight/1.6f, buttonWidth, buttonHeight), "Restart")){
			
			Application.LoadLevel("MainMenu");
		}
		if(GUI.Button (new Rect(screenWidth/2.1f, screenHeight/1.5f, buttonWidth, buttonHeight), "QUIT GAME")){
			
			Application.Quit ();
		}

	}
}
