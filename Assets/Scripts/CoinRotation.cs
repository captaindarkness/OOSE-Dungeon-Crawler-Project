using System;
using UnityEngine;

public class CoinRotation : MonoBehaviour
{
	private void Update()
	{
		transform.Rotate(Vector3.forward * Time.deltaTime * 100);
	}
}