using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour {

	float m_maxEnergy;
	public float m_energy {get; private set;}

	[Header("Rate for energy to decrease")]
	[SerializeField]
	float m_rate;

	#region Mono
	void Awake() {
		Setup();
	}

	void Setup(){
		m_energy = 100;
		m_maxEnergy = 100;
	}
	#endregion

	#region Energy Change

	public void DecrementEnergy() {
		m_energy -= m_rate;
		PrintEnergy ();
	}

	public void NoMoreEnergy() {
		m_energy = 0;
		PrintEnergy ();
	}

	public bool IsEnoughEnergy() {
		return m_energy > 0;
	}

	public void RefillEnergy(){
		float CalculatedEnergy = m_energy + m_rate * 5;
		if (CalculatedEnergy < m_maxEnergy ){
			m_energy = CalculatedEnergy;
		} else {
			m_energy = m_maxEnergy;
		}
		PrintEnergy ();
	}
	#endregion

	#region DEBUG
	void PrintEnergy(){
		DebugText.instance.SetDebugText ("Energy: " + m_energy);
	}
	#endregion
}
