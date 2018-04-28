using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayTextAnim : MonoBehaviour {

    [SerializeField]
    float m_AlphaTime;
    float m_CurrentTime = 0;

    [SerializeField]
    float m_TargetAlpha;

    bool m_AlphaDirection = false;


	// Update is called once per frame
	void Update () {
        m_CurrentTime += Time.deltaTime;
        if (m_CurrentTime > m_AlphaTime){
            m_AlphaDirection = !m_AlphaDirection;
            m_CurrentTime = 0;
            SwapAlpha(m_AlphaDirection);
        }
	}

    void SwapAlpha(bool alpha){
        float targetAlpha = 1;
        if (alpha) {
            targetAlpha = m_TargetAlpha;
        }
        GetComponent<Text>().CrossFadeAlpha(targetAlpha, m_AlphaTime, true);
    }
}
