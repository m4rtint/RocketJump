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
		
	public void StartFadeOutToMenu() {
        StateManager.instance.SetState(GameState.Menu);
        StartFadeOutProcessWithCoroutine();
	}

	public void StartFadeOutToGame() {
        StateManager.instance.SetState(GameState.Game);
        StartFadeOutProcessWithCoroutine();
	}

    void StartFadeOutProcessWithCoroutine()
    {
        FadeOut();
        StartCoroutine("StartChangeScene");
        //AUDIO
        AudioManager.instance.MenuClick();
    }

	void FadeOut() {
		gameObject.SetActive (true);
		m_ScreenCover_Renderer.SetAlpha (0);
		m_ScreenCover.CrossFadeAlpha (1, m_TimeTakenToFade, true);
	}

	IEnumerator DeactivateBlackScreen() {
		yield return new WaitForSeconds (m_TimeTakenToFade);
		gameObject.SetActive (false);
	}
	#endregion

	#region SceneChange
	IEnumerator StartChangeScene() {
		yield return new WaitForSeconds (m_TimeTakenToFade);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
	#endregion
}
