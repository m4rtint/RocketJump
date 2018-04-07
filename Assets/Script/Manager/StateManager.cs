﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {
	Menu,
	Game,
	GameOver
}

public class StateManager : MonoBehaviour {

	public static StateManager instance = null;

	[SerializeField]
	GameState m_CurrentState;

	void Awake() {
		//Check if instance already exists
		if (instance == null)

			//if not, set instance to this
			instance = this;

		//If instance already exists and it's not this:
		else if (instance != this)

			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);    

		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);
	}

	public void NextState() {
		switch (m_CurrentState) {
		case GameState.Game:
			m_CurrentState = GameState.GameOver;
			break;
		case GameState.GameOver:
			m_CurrentState = GameState.Menu;
			break;
		case GameState.Menu:
			m_CurrentState = GameState.Game;
			break;
		}
	}

	public GameState CurrentState() {
		return m_CurrentState;
	}

	public int CurrentStateInteger() {
		return (int)m_CurrentState;
	}

	public void SetState(GameState state) {
		m_CurrentState = state;
	}
}
