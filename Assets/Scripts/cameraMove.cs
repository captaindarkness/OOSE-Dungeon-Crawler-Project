using UnityEngine;
using System.Collections;

public class cameraMove : MonoBehaviour
{

	void Update () 
	{
		//Defines the player object
		GameObject player = GameObject.Find ("Player");
		//Access the player transform
		Transform playerTransform = player.transform;
		// get player position
		Vector3 position = playerTransform.position;
		//Debug.Log (position.x + " " + position.z);

		//Map1 camera
		//If player position between -10 and 10 coordinate in the game world
		if (position.x > -10 && position.x < 10 && position.z > -10 && position.z < 10) 
		{
			//New vector to hold the new position
			Vector3 move = new Vector3(0,17.5f,0);
			//Make transform position equal to the new position
			transform.position = move;
			//Debug.Log ("Here1");
		}

		//Map2 camera
		//If player position between 10 and 30 coordinate in the game world
		if (position.x > 10 && position.x < 30) 
		{
			//New vector to hold the new position
			Vector3 move = new Vector3(15,15,0);
			//Make transform position equal to the new position
			transform.position = move;
			//Debug.Log ("Here2");
		}
				
	}
}
