using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour {

	[SerializeField]
	float m_TimeTakenToFade;
	[SerializeField]
	string[] m_SceneNames;

	Image m_ScreenCover;

	#region Mono
	//If GameObject set as active in the beginning on scene Fade in
	void Awake() {
		m_ScreenCover = GetComponent<Image> ();
	}

	void Start() {
		FadeInIfNeeded ();
	}

	#endregion

	#region Fade
	void FadeInIfNeeded() {
		if (StateManager.instance.CurrentState () == GameState.Game) {
			StartFadeIn ();	
		}
	}
	public void StartFadeIn() {
		m_ScreenCover.color = Color.black;
		m_ScreenCover.CrossFadeAlpha (0, m_TimeTakenToFade, true);
	}

	public void StartFadeOut() {
		m_ScreenCover.color = Color.clear;
		m_ScreenCover.CrossFadeAlpha (1, m_TimeTakenToFade, true);
		StartCoroutine ("StartChangeScene");

	}
	#endregion

	#region SceneChange
	IEnumerator StartChangeScene(){
		yield return new WaitForSeconds (m_TimeTakenToFade);
		ChangeScene ();
	}

	void ChangeScene () {
		StateManager.instance.NextState ();
		string SceneName = m_SceneNames [StateManager.instance.CurrentStateInteger ()];
		SceneManager.LoadScene (SceneName);
	}

	#endregion
}
