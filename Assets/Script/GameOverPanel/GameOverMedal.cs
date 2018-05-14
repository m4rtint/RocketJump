using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMedal : MonoBehaviour {

	[SerializeField]
	Sprite[] m_medals;  
    
	#if UNITY_EDITOR
	[Range(-1,3)]
	public int debugScore;
	#endif

	public void SetImageFromArrayWith(int score){
		if (score >= 10) {
			Sprite medal = m_medals [0];
			if (score >= 50) {
				medal = m_medals [2];
			} else if (score >= 30) {
				medal = m_medals[1];
			}
			GetComponent<Image> ().sprite = medal;
		} 

		#if UNITY_EDITOR
		if (debugScore > -1) {
            GetComponent<Image> ().sprite = m_medals[debugScore];
		}
		#endif
	}
}
