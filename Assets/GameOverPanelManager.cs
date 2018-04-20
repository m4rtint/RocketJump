using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverPanelManager : MonoBehaviour {

	[SerializeField]
	GameObject m_gameOverScore;
	[SerializeField]
	GameObject m_medalImage;


	public void SetMedal() {
		m_medalImage.GetComponent<GameOverMedal> ().SetImageFromArrayWith(ScoreManager.instance.m_score);
	}

	public void UpdateGameOverScore(){
		string scoreDisplay = "Score: " + ScoreManager.instance.m_score+"\nBest Score: " + ScoreManager.instance.HighScore();
		m_gameOverScore.GetComponent<TextMeshProUGUI> ().text = scoreDisplay;
	}
}
