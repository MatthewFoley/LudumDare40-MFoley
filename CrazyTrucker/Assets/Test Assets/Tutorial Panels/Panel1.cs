using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel1 : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		Time.timeScale = 0f;
	}

	public void ContinueOne ()
	{
		Time.timeScale = 1f;
		//Destroy(gameObject);
		gameObject.SetActive(false);
	}
	

}
