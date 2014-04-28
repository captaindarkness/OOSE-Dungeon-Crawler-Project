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

		if (position.x > transform.position.x + 10)
		{
			//New vector to hold the new position
			Vector3 move = new Vector3(transform.position.x + 20,19,transform.position.z);
			//Make transform position equal to the new position
			transform.position = move;
			//Debug.Log ("Here1");
		}
		else if(position.x < transform.position.x - 10){
			//New vector to hold the new position
			Vector3 move = new Vector3(transform.position.x - 20,19,transform.position.z);
			//Make transform position equal to the new position
			transform.position = move;
			//Debug.Log ("Here1");
		}
		if (position.z > transform.position.z + 10)
		{
			//New vector to hold the new position
			Vector3 move = new Vector3(transform.position.x,19,transform.position.z + 20);
			//Make transform position equal to the new position
			transform.position = move;
			//Debug.Log ("Here1");
		}
		else if(position.z < transform.position.z - 10){
			//New vector to hold the new position
			Vector3 move = new Vector3(transform.position.x,19,transform.position.z -20);
			//Make transform position equal to the new position
			transform.position = move;
			//Debug.Log ("Here1");
		}
	}
}
