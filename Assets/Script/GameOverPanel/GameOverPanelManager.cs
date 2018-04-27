using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanelManager : MonoBehaviour {

	[SerializeField]
	GameObject m_gameOverScore;
	[SerializeField]
	GameObject m_bestScore;
	[SerializeField]
	GameObject m_medalImage;


	public void SetMedal() {
		m_medalImage.GetComponent<GameOverMedal> ().SetImageFromArrayWith(ScoreManager.instance.m_score);
	}

	public void UpdateGameOverScore(){
		string scoreDisplay = "Score: " + ScoreManager.instance.m_score+"\nBest Score: " + ScoreManager.instance.HighScore();
		m_gameOverScore.GetComponent<Text> ().text = scoreDisplay;
	}

	public void UpdateGameOverBestScore() {
		string bestScoreDisplay = "Score:\n" + ScoreManager.instance.HighScore ();
			m_bestScore.GetComponent<Text>().text = bestScoreDisplay;
	}
}
