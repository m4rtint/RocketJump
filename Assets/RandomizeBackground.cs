using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeBackground : MonoBehaviour {

    [SerializeField]
    Sprite[] m_backgrounds;
	// Use this for initialization
	void Start () {
        int num = (Random.Range(0, 10) % 2 == 0) ? 0 : 1;
        GetComponent<SpriteRenderer>().sprite = m_backgrounds[num];
	}
}
