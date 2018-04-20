﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour {
	
	public static AudioManager instance = null;

	AudioSource[] m_audioSources;
	AudioData AUDIO;

    #region Mono
    void Awake() {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);
		SetupVariable ();
	}

	void SetupVariable() {
		m_audioSources = GetComponents<AudioSource> ();
        AUDIO = GetComponent<AudioData> ();
	}
	#endregion

	#region Controls
	void PLAY(AudioClip clip, int source, float volume = 1.0f) {
		m_audioSources[source].PlayOneShot (clip, volume);
	}

	public void STOP(){
        m_audioSources[0].Stop ();
        m_audioSources[1].Stop();
    }
	#endregion

	#region Public
	//Place Different Sound effects here
	public void MenuClick() {
		PLAY (AUDIO.MenuClick, 0);
	}

	public void Flap(){
		if (!m_audioSources[0].isPlaying) {
			PLAY (AUDIO.Flap, 0);
		}
	}

	public void Death() {
		PLAY (AUDIO.Death,0);
	}

	public void Point() {
		PLAY (AUDIO.Point,1);
	}
	#endregion
}
