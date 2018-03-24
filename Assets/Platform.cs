using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	public bool m_DidStepOn { get; private set;}

	void Awake() {
		m_DidStepOn = false;
	}

	#region DidStep
	public void SteppedOnPlatform(){
		m_DidStepOn = true;
		gameObject.transform.parent.parent.gameObject.GetComponent<MovementManager> ().StopSpeed ();
	}

	public void SteppedOffPlatform(){
		gameObject.transform.parent.parent.gameObject.GetComponent<MovementManager> ().PlaySpeed ();
	}

	public void reset(){
		m_DidStepOn = false;
	}
	#endregion
}
