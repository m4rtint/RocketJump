using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour {

	[Header("Canvas Items")]
	[SerializeField]
	GameObject m_GameOverPanel;
	[SerializeField]
	float m_LagTime;
    [Header("Game UI")]
	[SerializeField]
	GameObject m_EnergyBar;
	[SerializeField]
	GameObject m_Score;

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
        InitializeUI();

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
	#endregion

	#region Gameover Screen
	public void StartUpGameOverPanel() {
		StartCoroutine ("GameOverWithLag");
	}

	IEnumerator GameOverWithLag(){
		yield return new WaitForSeconds(m_LagTime);
		m_GameOverPanel.GetComponent<Animator> ().SetTrigger ("GameOver");
	}

	public void UpdateGameOverPanel() {
		m_GameOverPanel.GetComponent<GameOverPanelManager>().UpdateGameOverScore();
		m_GameOverPanel.GetComponent<GameOverPanelManager>().SetMedal();
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
	public void UpdateScore(float score) {
		m_Score.GetComponent<TextMeshProUGUI> ().text = score.ToString();
	}

	#endregion
		

}
