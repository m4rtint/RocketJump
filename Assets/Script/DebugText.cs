﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugText : MonoBehaviour {

	[SerializeField]
	GameObject EnergyText;

	[SerializeField]
	GameObject ScoreText;

	public static DebugText instance = null;


	//Awake is always called before any Start functions
	void Awake()
	{
		instance = this;
	}


	public void SetEnergyText(string text){
		EnergyText.GetComponent<Text> ().text = text;
	}

	public void SetScoreText(string text) {
		ScoreText.GetComponent<Text> ().text = text;
	}
}