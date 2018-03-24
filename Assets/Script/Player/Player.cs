using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour {

	Rigidbody2D m_RigidBody;
	[SerializeField]
	float upForce;

	Energy energy;

	#region Mono
	void Awake(){
		m_RigidBody = GetComponent<Rigidbody2D>();
		energy = GetComponent<Energy>();
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
		if(DidInput() && energy.IsEnoughEnergy()){
			Rocket ();
			energy.DecrementEnergy();
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

	#region Collision
	void OnCollisionEnter2D(Collision2D other) {
		GameObject otherObj = other.gameObject;
//		if (other.gameObject.tag == "Death"){
//			Death();
//		}

		if (otherObj.tag == "SafeZone"){
			//TODO - Check if platform already stepped on before
			otherObj.GetComponent<Platform>().SteppedOnPlatform();
//			ScoreManager.instance.IncrementScore();
		}
	}

	void OnCollisionStay2D(Collision2D other) {
		GameObject otherObj = other.gameObject;
		if (otherObj.tag == "SafeZone"){
			energy.RefillEnergy ();
		}
	}

	void OnCollisionExit2D(Collision2D other) {
		GameObject otherObj = other.gameObject;
		if (otherObj.tag == "SafeZone") {
			otherObj.GetComponent<Platform>().SteppedOffPlatform();
		}
	}
	#endregion

	#region Death

//	void Death() {
//		//Set Energy to 0
//		energy.NoMoreEnergy();
//
//		//Stop Platform Motion
//		MotionManager.instance.Stop();
//	}

	#endregion
}
