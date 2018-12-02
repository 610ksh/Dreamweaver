using UnityEngine;
using System.Collections;

public class DemoObjectScript : MonoBehaviour
{
	IEnumerator Start ()
	{
		//Little delay
		yield return new WaitForSeconds (2);

		//Here is how you can call your ITWEEN from a script
		this.GetComponent<iTweenAnimation> ().iTweenStart ();

		Destroy (this.gameObject, 3);
	}
}
