using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour {

	Rigidbody2D m_RigidBody;

	[SerializeField]
	GameObject m_spawnManager; 
	MovementManager m_moveManager;
    [SerializeField]
    GameObject m_loopingManager;
    LoopingManager m_looper;

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
		m_moveManager = m_spawnManager.GetComponent<MovementManager> ();
        m_looper = m_loopingManager.GetComponent<LoopingManager>();
    }


	void Update() {
		Movement();
	}

	#endregion
	#region Movement
	void Movement() {
		if(PlayerMovementAllowed()){
			Rocket ();
			m_energy.DecrementEnergy();
		}
	}

	bool DidInput() {
		return Input.GetMouseButton (0) || Input.GetKey(KeyCode.Space);
	}

	bool PlayerMovementAllowed() {
		return DidInput () && m_energy.IsEnoughEnergy () && StateManager.instance.CurrentState() == GameState.Game;
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
            StopMovingEnvironment();
			IncrementPoint (otherObj);
			
		}
	}

	void IncrementPoint(GameObject obj) {
		//Platform set as Stepped on
		Platform plat = obj.GetComponent<Platform> ();
		//Increment points
		if (!plat.m_DidStepOn) {
			ScoreManager.instance.IncrementScore ();
		}
		plat.SteppedOnPlatform ();

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
            StartMovingEnvironment();
        }
	}

    void StartMovingEnvironment()
    {
        m_moveManager.PlaySpeed();
        m_looper.PlayAllObjects();

    }

    void StopMovingEnvironment()
    {
        m_moveManager.StopSpeed();
        m_looper.StopAllObjects();
    }
	#endregion

	#region Death

	void Death() {
		if (StateManager.instance.CurrentState() != GameState.Game) {
			return;
		}
        //Stop Environment from moving
        StopMovingEnvironment();
		//Set Energy to 0
		m_energy.NoMoreEnergy();
		//Set State
		StateManager.instance.NextState();
		//Save Score
		ScoreManager.instance.SaveScore();
		//Setup Game Over Panel
		UIManager.instance.StartUpGameOverPanel();
		//AUDIO
		AudioManager.instance.Death();
	}
		

	#endregion
}
