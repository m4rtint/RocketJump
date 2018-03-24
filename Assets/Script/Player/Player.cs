using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour {

	Rigidbody2D m_RigidBody;

	[SerializeField]
	GameObject SpawnManager; 
	MovementManager m_moveManager;
	//Player Property
	public bool alive = true;

	//Physics
	[SerializeField]
	float upForce;
	Energy m_energy;

	//Tags
	string m_DeathTag = "Death";
	string m_SafeZone = "SafeZone";

	#region Mono
	void Awake(){
		m_RigidBody = GetComponent<Rigidbody2D>();
		m_energy = GetComponent<Energy>();
		m_moveManager = SpawnManager.GetComponent<MovementManager> ();
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
		if(DidInput() && m_energy.IsEnoughEnergy()){
			Rocket ();
			m_energy.DecrementEnergy();
		}
	}

	bool DidInput() {
		return Input.GetMouseButton (0) || Input.GetKey(KeyCode.Space);
	}

	void Rocket() {
		m_RigidBody.velocity = Vector3.zero;
		m_RigidBody.AddForce(Vector3.up*upForce);
	}
	#endregion

	#region Collision
	void OnCollisionEnter2D(Collision2D other) {
		GameObject otherObj = other.gameObject;
		if (other.gameObject.tag == m_DeathTag){
			Death();
		}

		if (otherObj.tag == m_SafeZone){
			//Check if platform already stepped on before
			m_moveManager.StopSpeed();
//			ScoreManager.instance.IncrementScore();
		}
	}

	void OnCollisionStay2D(Collision2D other) {
		GameObject otherObj = other.gameObject;
		if (otherObj.tag == m_SafeZone){
			m_energy.RefillEnergy ();
		}
	}

	void OnCollisionExit2D(Collision2D other) {
		GameObject otherObj = other.gameObject;
		if (otherObj.tag == m_SafeZone) {
			m_moveManager.PlaySpeed ();
		}
	}
	#endregion

	#region Death

	void Death() {
		//Set Energy to 0
		m_energy.NoMoreEnergy();

		//TODO Change this to state
		alive = false;
		//Stop Platform Motion
		m_moveManager.StopSpeed();
		DebugText.instance.SetDebugText ("Death");
		StartCoroutine ("Respawn");
	}


	//DEBUG
	IEnumerator Respawn() {
		yield return new WaitForSeconds(3);
		SceneManager.LoadScene (0);
	}

	#endregion
}
