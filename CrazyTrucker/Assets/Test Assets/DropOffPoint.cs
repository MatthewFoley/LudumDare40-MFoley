using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOffPoint : MonoBehaviour {

	public PackageCollector packages;
	public Rigidbody truckMass;
	public GameManager manager;
	float  score = 0;
	float timer;
	public AudioSource dropOff;
	bool firstDropOff;
	public GameObject tutorial3;

	void Start()
	{
		firstDropOff = true;
	}

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
				dropOff.Play ();
				if (firstDropOff == true) 
				{
					firstDropOff = false;
					tutorial3.SetActive (true);

				}
			}
		}
	}
}
