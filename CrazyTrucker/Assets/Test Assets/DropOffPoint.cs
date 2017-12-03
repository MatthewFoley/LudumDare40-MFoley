using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOffPoint : MonoBehaviour {

	public PackageCollector packages;
	public Rigidbody truckMass;

	void OnTriggerEnter(Collider col)
	{
		if (col.CompareTag ("Player")) 
		{
			packages.storedPackages = 0;
			truckMass.mass = 400;
		}
	}
}
