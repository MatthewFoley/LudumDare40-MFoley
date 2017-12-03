using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {

	public void Yes ()
	{
		SceneManager.LoadScene ("Level1");
	}

	public void No()
	{
		SceneManager.LoadScene ("MainMenu");
	}


}
