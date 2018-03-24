using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {
	Game,
	GameOver
}

public class StateManager : MonoBehaviour {

	public static StateManager instance = null;

	public GameState m_CurrentState { get; private set;}

	void Awake() {
		instance = this;
		m_CurrentState = (GameState)0;
	}

	public void NextState() {
		m_CurrentState = (GameState)(CurrentStateInteger()+1);
	}

	public GameState CurrentState() {
		return m_CurrentState;
	}

	public int CurrentStateInteger() {
		return (int)m_CurrentState;
	}
}
