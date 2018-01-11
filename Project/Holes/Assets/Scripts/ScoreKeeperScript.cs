using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeperScript : MonoBehaviour {

	int CurrentScore;
	public int DefaultScoreIncrement = 50;

	public Text ScoreText;

	void Start () {
		CurrentScore = 0;
	}
	void Update () {
		ScoreText.text = "Score: " + CurrentScore.ToString();
	}

	public void IncrementScore(int _increment)
	{
		CurrentScore += _increment;
	}
	public void IncrementScore()
	{
		CurrentScore += DefaultScoreIncrement;
	}
}
