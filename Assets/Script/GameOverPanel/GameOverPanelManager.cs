using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanelManager : MonoBehaviour {

	[Header("Fade In Elements")]
	[SerializeField]
	GameObject m_GameOverUI;
	[SerializeField]
	float m_TimeTakenToFadeIn;
    [SerializeField]
    float m_TimeTakenForButtonsToComeIn;

	[Header("Game Over UI")]
	[SerializeField]
	GameObject m_gameOverScore;
	[SerializeField]
	GameObject m_bestScore;
	[SerializeField]
	GameObject m_medalImage;
    [SerializeField]
    bool isWinterTheme;

	//CanvasRenderer
    GameObject[] m_GameObjectsWithImage;
    GameObject[] m_GameObjectsWithText;


    [Header("Buttons")]
    [SerializeField]
    GameObject m_Menu;
    [SerializeField]
    GameObject m_Replay;
    [SerializeField]
    GameObject m_Rate;


#region Mono
	void Awake() {
		SetupComponents();
        SetupScore();
        SetupUI();
        StartFadeIn();
	}

    void SetupComponents()
    {
        m_GameObjectsWithImage = new GameObject[] { m_GameOverUI, m_medalImage };
        m_GameObjectsWithText = new GameObject[] { m_bestScore, m_gameOverScore };
    }

    void SetupColor(GameObject[] objs)
    {
        for (int i = 0; i < objs.Length; i++)
        {
            objs[i].GetComponent<CanvasRenderer>().SetAlpha(0);
        }
    }

    void SetupScore(){
        UpdateGameOverScore();
        UpdateGameOverBestScore();
        SetMedal();
    }

    void SetupUI(){
        SetupColor(m_GameObjectsWithText);
        SetupColor(m_GameObjectsWithImage);
    }

    void StartFadeIn() {
        FadeInText();
        FadeInImage();
        StartCoroutine("StartButtonAnimation");
    }


    IEnumerator StartButtonAnimation() {
        yield return new WaitForSeconds(m_TimeTakenForButtonsToComeIn/2);
        StartCoroutine("StartButtonPopOut");
    }
#endregion

#region FadeIn
	void FadeInImage() {
		for(int i = 0; i < m_GameObjectsWithImage.Length; i++) {
            m_GameObjectsWithImage[i].GetComponent<Image>().CrossFadeAlpha (1, m_TimeTakenToFadeIn, true);
        }
	}

    void FadeInText(){
        for (int i = 0; i < m_GameObjectsWithText.Length; i++) {
            m_GameObjectsWithText[i].GetComponent<Text>().CrossFadeAlpha(1, m_TimeTakenToFadeIn, true);
        }
    }

    #endregion

    #region Button
    IEnumerator StartButtonPopOut() {
        string PopOutTrigger = "ShowHome";
        float lagTime = 0.1f;
		m_Replay.GetComponent<Animator>().SetTrigger(PopOutTrigger);
		yield return new WaitForSeconds(lagTime);
        m_Menu.GetComponent<Animator>().SetTrigger(PopOutTrigger);
        m_Rate.GetComponent<Animator>().SetTrigger(PopOutTrigger);
    }
#endregion

    #region SetUI
    void SetMedal() {
		m_medalImage.GetComponent<GameOverMedal> ().SetImageFromArrayWith(ScoreManager.instance.m_score);
	}

	void UpdateGameOverScore(){
        string score = isWinterTheme? "Score:\n" : "SCORE:\n";
		string scoreDisplay = score + ScoreManager.instance.m_score;
		m_gameOverScore.GetComponent<Text> ().text = scoreDisplay;
	}

	void UpdateGameOverBestScore() {
        string best = isWinterTheme ? "Best:\n" : "BEST:\n";
        string bestScoreDisplay = best + ScoreManager.instance.HighScore ();
			m_bestScore.GetComponent<Text>().text = bestScoreDisplay;
	}
#endregion
}
