using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageCollector : MonoBehaviour {

	GameObject[] package;
	public int storedPackages;
	public Rigidbody truckMass;
	public float massModifer;


	void OnTriggerEnter(Collider col)
	{
		if (col.CompareTag ("Delivery")) 
		{
			Destroy (col.gameObject);
			storedPackages++;
			massModifer = 20 * storedPackages;
			truckMass.mass += massModifer;
		}
	}
}
