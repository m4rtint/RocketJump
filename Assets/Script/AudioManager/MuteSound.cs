using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class MuteSound : MonoBehaviour {

	[Header("Mute Button Images")]
	[SerializeField]
	Sprite m_muted;
	[SerializeField]
	Sprite m_unMuted;

	#region Mono
	void Start() {
		UpdateButtonImage ();
	}

	void UpdateButtonImage(){
		Sprite image = AudioManager.instance.IsMuted () ? m_muted : m_unMuted;
		GetComponent<Image> ().sprite = image;
	}
	#endregion

	#region Controls
	public void PressedMuteButton() {
		bool mute = AudioManager.instance.IsMuted ();
		AudioManager.instance.MUTE(!mute);
		UpdateButtonImage ();

		//AUDIO
		AudioManager.instance.MenuClick();
	}
	#endregion
}
