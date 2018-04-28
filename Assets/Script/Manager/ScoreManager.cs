using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager instance = null;
	public int m_score {get; private set;}

	void Awake(){
		instance = this;
		m_score = -1;
	}

	public void IncrementScore(){
		m_score++;
		UIManager.instance.UpdateGameScore (m_score);
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
