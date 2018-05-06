using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	[Header("GameOver")]
	[SerializeField]
	GameObject m_GameOverPanel;
	[SerializeField]
	float m_LagTime;

    [Header("Game UI")]
	[SerializeField]
	GameObject m_EnergyBar;
	[SerializeField]
	GameObject m_GameScore;

	[Header("Menu UI")]
	[SerializeField]
	GameObject m_MenuScore;

    [Header("Canvas Categories")]
    [SerializeField]
    GameObject m_MenuUI;
    [SerializeField]
    GameObject m_GameUI;

    [Header("Game Properties")]
	[SerializeField]
	GameObject m_PlayerObject;
	Energy m_energy;
	Vector3 m_energyScale = Vector3.one;
	public static UIManager instance = null;





	#region Mono
	void Awake() {
		instance = this;
		m_energy = m_PlayerObject.GetComponent<Energy> ();
		InitializeDelegate ();
    }

    void Start() {
        InitializeUI();
        InitializeMenuScore();
    }

    void InitializeUI()
    {
		bool isMenu = StateManager.instance.EqualMenu();
        m_MenuUI.SetActive(isMenu);
        m_GameUI.SetActive(!isMenu);
    }

	void InitializeDelegate() {
		m_energy.onEnergyUpdate += UpdateEnergy;
	}

	void InitializeMenuScore(){
		m_MenuScore.GetComponent<Text>().text = "Best Score: "+ScoreManager.instance.HighScore();
	}
	#endregion

	#region Gameover Screen
	public void StartUpGameOverPanel() {
        m_GameOverPanel.SetActive(true);
        m_GameUI.SetActive(false);
	}
    #endregion

    #region MenuTransition
    public void TransitionFromMenuToGame()
    {
        m_MenuUI.SetActive(false);
        m_GameUI.SetActive(true);
        StateManager.instance.NextState();
    }
    #endregion

    #region Energy UI
    void UpdateEnergy(float energy) {
		m_energyScale.x = energy / m_energy.m_maxEnergy;
		m_EnergyBar.GetComponent<RectTransform> ().localScale = m_energyScale;
	}
	#endregion

	#region Score UI
	public void UpdateGameScore(float score) {
		m_GameScore.GetComponent<Text> ().text = score.ToString();
	}

	#endregion

}
