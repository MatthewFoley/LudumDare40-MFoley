using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOffPoint : MonoBehaviour {

	public PackageCollector packages;
	public Rigidbody truckMass;
	public GameManager manager;
	float  score = 0;
	float timer;

	void OnTriggerEnter(Collider col)
	{
		if (col.CompareTag ("Player")) 
		{
			if (packages.storedPackages > 0) 
			{
				score = manager.playerScore + (packages.storedPackages * 10);
				timer = manager.playerTimer + (packages.storedPackages * 30);
				manager.playerTimer = timer;
				manager.playerScore = score;
				packages.storedPackages = 0;
				truckMass.mass = 400;
			}
		}
	}
}
