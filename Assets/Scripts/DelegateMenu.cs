using UnityEngine;
using System.Collections;

public class DelegateMenu : MonoBehaviour {

	private delegate void MenuDelegate();
	private MenuDelegate menuFunction;

	private float screenHeight;
	private float screenWidth;
	private float buttonHeight;
	private float buttonWidth;


	// Use this for initialization
	void Start () {

		screenHeight = Screen.height;
		screenWidth = Screen.width;

		buttonHeight = screenHeight * 0.3f;
		buttonWidth = screenWidth * 0.4f;

		menuFunction = anyKey;
	}

	void OnGUI(){

		menuFunction();
	}

	void anyKey(){

		if(Input.anyKey){

			menuFunction = mainMenu;
		}

		//Sets GUI to be placed in the middle.
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;

		GUI.Label (new Rect(screenWidth * 0.45f, screenHeight * 0.45f, screenWidth * 0.1f, screenHeight * 0.1f),"PRESS ANY KEY TO CONTINUE");
	}

	void mainMenu(){
		//Button for loading level.
		if(GUI.Button (new Rect((screenWidth - buttonWidth) * 0.5f, screenHeight * 0.1f, buttonWidth, buttonHeight), "START GAME")){

			Application.LoadLevel("Level");
		}
		//Button for quitting game.
		if(GUI.Button (new Rect((screenWidth - buttonWidth) * 0.5f, screenHeight * 0.5f, buttonWidth, buttonHeight), "QUIT GAME")){

			Application.Quit ();
		}

	}
}
