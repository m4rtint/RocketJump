using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackScreenFade : MonoBehaviour {

	[SerializeField]
	float TimeTakenToFade;

	Image m_ScreenCover;

	#region Mono
	//If GameObject set as active in the beginning on scene Fade in
	void Awake() {
		m_ScreenCover = GetComponent<Image> ();
	}

	#endregion

	#region active
	public void StartFadeIn() {
		m_ScreenCover.color = Color.black;
		m_ScreenCover.CrossFadeAlpha (0, TimeTakenToFade, true);
	}

	public void StartFadeOut() {
		m_ScreenCover.color = Color.clear;
		m_ScreenCover.CrossFadeAlpha (1, TimeTakenToFade, true);
	}
	#endregion
}
