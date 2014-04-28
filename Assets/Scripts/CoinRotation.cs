using System;
using UnityEngine;

public class CoinRotation : MonoBehaviour
{
	// Update is called once per frame
	private void Update()
	{
		//The object rotates around itself.
		transform.Rotate(Vector3.forward * Time.deltaTime * 100);
	}
}