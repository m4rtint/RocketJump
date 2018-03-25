using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager instance = null;
	public int m_score {get; private set;}

	void Awake(){
		instance = this;
		m_score = 0;
	}

	public void IncrementScore(){
		m_score++;
		DebugText.instance.SetScoreText ("Score: " + m_score +"\nBestScore: "+HighScore());
	}

	public void SaveScore() {
		if (HighScore () < m_score) {
			PlayerPrefs.SetInt ("HighScore", m_score);
		}
	}

	public int HighScore() {
		return PlayerPrefs.GetInt ("HighScore");
	}
		
}
