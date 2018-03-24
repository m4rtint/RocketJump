using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour {

	Rigidbody2D m_RigidBody;
	[SerializeField]
	float upForce;

//	Energy energy;

	#region Mono
	void Awake(){
		m_RigidBody = GetComponent<Rigidbody2D>();
//		energy = GetComponent<Energy>();
	}


	void Update() {
		Movement();
	}

	#endregion
	#region Movement
	void Movement() {
//		if (StateManager.instance.CurrentState != Game) {
//			//TODO Freeze everything
//		}
		if(DidInput()){
			Debug.Log ("Input");
			Rocket ();
//			GetComponent<Energy>().DecrementEnergy();
		}
	}

	bool DidInput() {
		return Input.GetMouseButton (0);
	}

	void Rocket() {
		m_RigidBody.velocity = Vector3.zero;
		m_RigidBody.AddForce(Vector3.up*upForce);
	}
	#endregion

	#region Death
//	void OnCollisionEnter2D(Collision2D other) {
//		if (other.tag == "Death"){
//			Death();
//		}
//
//		if (other.tag == "safezone"){
//			//TODO - Check if platform already stepped on before
//			other.GetComponent<Platform>().SteppedOnPlatform();
//			ScoreManager.instance.IncrementScore();
//		}
//	}

//	void Death() {
//		//Set Energy to 0
//		energy.NoMoreEnergy();
//
//		//Stop Platform Motion
//		MotionManager.instance.Stop();
//	}

	#endregion
}
