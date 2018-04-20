using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverPanelManager : MonoBehaviour {

	[SerializeField]
	GameObject m_gameOverScore;
	[SerializeField]
	GameObject m_medalImage;

	ScoreManager scoreManager;

	void Awake() {
		scoreManager = ScoreManager.instance;
	}

	public void SetMedal() {
		m_medalImage.GetComponent<GameOverMedal> ().SetImageFromArrayWith (scoreManager.m_score);
	}

	public void UpdateGameOverScore(){
		string scoreDisplay = "Score: "+scoreManager.m_score+"\nBest Score: "+scoreManager.HighScore();
		m_gameOverScore.GetComponent<TextMeshProUGUI> ().text = scoreDisplay;
	}
}
