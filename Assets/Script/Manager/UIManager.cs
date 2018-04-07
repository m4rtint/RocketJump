using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour {

	[Header("Canvas Items")]
	[SerializeField]
	GameObject m_GameOverPanel;
	[SerializeField]
	float m_LagTimeBeforeRising;
	[SerializeField]
	GameObject m_EnergyBar;
	[SerializeField]
	GameObject m_Score;

	[Header("Game Properties")]
	[SerializeField]
	GameObject m_Player;
	Energy m_energy;
	Vector3 m_energyScale = Vector3.one;
	public static UIManager instance = null;

	#region Mono
	void Awake() {
		instance = this;
		m_energy = m_Player.GetComponent<Energy> ();
		InitializeDelegate ();
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
		yield return new WaitForSeconds(m_LagTimeBeforeRising);
		m_GameOverPanel.GetComponent<Animator> ().SetTrigger ("GameOver");
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
