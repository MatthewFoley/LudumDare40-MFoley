using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public Text score;
	public Text timer;
	public Text crateCounter;
	public float playerScore;
	public float playerTimer;
	public float crateCount;
	public int tempTimer;
	public PackageCollector package;

	void Start()
	{
		playerTimer = 120;
		playerScore = 0;
	}

	void Update()
	{
		tempTimer = (Mathf.RoundToInt(playerTimer));
		crateCount = package.storedPackages;
		playerTimer -= Time.deltaTime;
		crateCounter.text = crateCount.ToString ();
		timer.text = tempTimer.ToString ();
		score.text = playerScore.ToString ();

		if (playerTimer < 0) 
		{
			SceneManager.LoadScene ("GameOver");
		}
	}



}
