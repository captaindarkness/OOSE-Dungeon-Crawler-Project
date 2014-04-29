using UnityEngine;
using System.Collections;

public class Thunder : MonoBehaviour {
	public float rand;
	public AudioSource thunder;
	
	IEnumerator Start ()
	{
		//Continues while loop that will will turn the Light of the Directional light on and off between 15 and 25 seconds
		while (true)
		{
			rand = Random.Range (15,25);
			light.enabled = false;
			yield return new WaitForSeconds(rand);
			light.enabled = true;
			thunder.Play ();
			yield return new WaitForSeconds(0.1f);
			light.enabled = false;
			yield return new WaitForSeconds(0.1f);
			light.enabled = true;
			yield return new WaitForSeconds(0.5f);
	
		}
	}

	// Update is called once per frame
	void Update () {
	}
	
}
