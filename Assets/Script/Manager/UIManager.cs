using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	[Header("Canvas Items")]
	[SerializeField]
	GameObject m_GameOverPanel;
	[SerializeField]
	float m_LagTimeBeforeRising;

	public static UIManager instance = null;

	#region Mono
	void Awake() {
		instance = this;
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
		

}
