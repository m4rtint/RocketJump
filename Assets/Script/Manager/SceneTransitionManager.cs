using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour {

	[SerializeField]
	float m_TimeTakenToFade;

	Image m_ScreenCover;
	CanvasRenderer m_ScreenCover_Renderer;

	#region Mono
	//If GameObject set as active in the beginning on scene Fade in
	void Awake() {
		m_ScreenCover = GetComponent<Image> ();
		m_ScreenCover_Renderer = GetComponent<CanvasRenderer> ();
	}

	void Start() {
		StartFadeIn ();
		SetupColor ();
	}

	void SetupColor() {
		m_ScreenCover.color = Color.black;
	}
	#endregion

	#region Fade

	public void StartFadeIn() {
		m_ScreenCover_Renderer.SetAlpha (1);
		m_ScreenCover.CrossFadeAlpha (0, m_TimeTakenToFade, true);
		StartCoroutine ("DeactivateBlackScreen");
	}

	public void StartFadeOut() {
		gameObject.SetActive (true);
		m_ScreenCover_Renderer.SetAlpha (0);
		m_ScreenCover.CrossFadeAlpha (1, m_TimeTakenToFade, true);
		StartCoroutine ("StartChangeScene");
	}

	IEnumerator DeactivateBlackScreen() {
		yield return new WaitForSeconds (m_TimeTakenToFade);
		gameObject.SetActive (false);
	}
	#endregion

	#region SceneChange
	IEnumerator StartChangeScene(){
		yield return new WaitForSeconds (m_TimeTakenToFade);
		ChangeScene ();
	}

	void ChangeScene () {
		StateManager.instance.NextState ();
		SceneManager.LoadScene (GetNextSceneIndex ());
	}

	int GetNextSceneIndex() {
		int numberOfScenes = SceneManager.sceneCountInBuildSettings;
		int currentScene = SceneManager.GetActiveScene ().buildIndex;
		currentScene++;

		//Reset back to scene 0
		if (currentScene >= numberOfScenes) {
			currentScene = 0;
		}

		return currentScene;

	}

	#endregion
}
