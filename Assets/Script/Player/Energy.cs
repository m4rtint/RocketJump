using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour {

	public delegate void EnergyDelegate(float energy);
	public EnergyDelegate onEnergyUpdate;

	public float m_maxEnergy { get; private set; }
	public float m_energy {get; private set;}

	[Header("Rate for energy to decrease")]
	[SerializeField]
	float m_rate;

	#if UNITY_EDITOR
	[Header("DEBUG")]
	public bool InfiniteEnergy;
	#endif

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

		if (m_energy < 0) {
			m_energy = 0;
		}
		onEnergyUpdate (m_energy);
	}

	public void NoMoreEnergy() {
		m_energy = 0;
		onEnergyUpdate (m_energy);
	}

	public bool IsEnoughEnergy() {
		#if UNITY_EDITOR
		if (InfiniteEnergy){
			return InfiniteEnergy;
		} 
		#endif
		return m_energy > 0;

	}

	public void RefillEnergy(){
		//Change this to checking the state
		if (StateManager.instance.CurrentState() == GameState.GameOver) {return;}

		float CalculatedEnergy = m_energy + m_rate * 2;
		if (CalculatedEnergy < m_maxEnergy ){
			m_energy = CalculatedEnergy;
		} else {
			m_energy = m_maxEnergy;
		}
		onEnergyUpdate (m_energy);
	}
	#endregion

}
