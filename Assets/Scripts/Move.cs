using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown(KeyCode.A)){
			transform.position -= new Vector3(2.0f, 0, 0);//move left
		}
		if(Input.GetKeyDown(KeyCode.D)){
			transform.position += new Vector3(2.0f, 0, 0);//move right
		}
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position += new Vector3(0, 2.0f, 0);//move right
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position -= new Vector3(0, 2.0f, 0);//move right
        }
		if(Input.GetButtonDown("Jump") && transform.position.y < 1){//Jump with limit on
			rigidbody.AddForce(new Vector3(0, 400.0f, 0));
		}
		
	}
}
