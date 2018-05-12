using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour {
	
	public static AudioManager instance = null;

	AudioSource[] m_audioSources;
	AudioData AUDIO;

    [SerializeField]
    bool EasterEgg;

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

	#region Mute
	void SetMute(bool mute) {
		int isMutedNumber = mute ? 1 : 0;
		PlayerPrefs.SetInt ("Mute", isMutedNumber);
	}

	//Muted - 1 : True 
	//Not Muted - 0 : False
	public bool IsMuted() {
		int isMuted = PlayerPrefs.GetInt ("Mute", 1);
		return (isMuted == 1);
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

	public void MUTE(bool turnOn) {
		m_audioSources [0].mute = turnOn;
		m_audioSources [1].mute = turnOn;
		SetMute (turnOn);
	}
	#endregion

	#region Sounds
	//Place Different Sound effects here
	public void MenuClick() {
        if (EasterEgg)
        {
            PLAY(AUDIO.EASTER_MenuClick, 0);
        } else
        { 
            PLAY (AUDIO.MenuClick, 0);
        }
    }

	public void Flap(){
		if (!m_audioSources[0].isPlaying) {
            if(EasterEgg)
            {
                PLAY(AUDIO.EASTER_Flap, 0);
            } else
            {
                PLAY(AUDIO.Flap, 0);
            }
        }
	}

	public void Death() {
        if (EasterEgg)
        {
            PLAY(AUDIO.EASTER_Death, 0);
        }
        else
        {
            PLAY(AUDIO.Death, 0);
        }
    }

	public void Point() {
        if (EasterEgg)
        {
            PLAY(AUDIO.EASTER_Point, 0);
        }
        else
        {
            PLAY(AUDIO.Point, 0);
        }
    }
	#endregion
}
