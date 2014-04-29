using UnityEngine;
using System.Collections;

public class YourFinalScore : MonoBehaviour {

	private float screenHeight;
	private float screenWidth;
	private float buttonHeight;
	private float buttonWidth;

	void Start () {
		
		screenHeight = Screen.height;
		screenWidth = Screen.width;
		
		buttonHeight = 30.0f;
		buttonWidth = 100.0f;

	}
	// Update is called once per frame
	void Update () {
		
	}

	void  OnGUI () {
		GUI.Label(new Rect(screenWidth/70.0f,screenHeight/60.0f,400,40),"<color=white><size=35>"+"Your final Score:"+"</size></color>");
		if(GUI.Button (new Rect((screenWidth - buttonWidth) * 0.5f, screenHeight * 0.5f, buttonWidth, buttonHeight), "QUIT GAME")){
			
			Application.Quit ();
		}
		
	}
}
