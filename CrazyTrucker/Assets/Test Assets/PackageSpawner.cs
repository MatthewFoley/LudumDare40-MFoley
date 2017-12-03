using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageSpawner : MonoBehaviour {


	public GameObject[] spawners = new GameObject[27];
	public GameObject package;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		GameObject[] packages = GameObject.FindGameObjectsWithTag ("Delivery");
		int numberOfPackages = packages.Length;

		if (numberOfPackages < 10) 
		{
			Instantiate (package, spawners [Random.Range (0, 26)].transform.position, new Quaternion (0, 0, 0, 0));
		}
	}
}
