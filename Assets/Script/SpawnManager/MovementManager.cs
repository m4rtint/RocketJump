using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour {

	List<GameObject> m_platforms = new List<GameObject>();

	[SerializeField]
	float m_speed;
	float m_speedChanges;

	[SerializeField]
	GameObject m_endSpawnGameObject;
	float m_endSpawn_X;



	#region Mono
	void Awake() {
		Setup ();
	}

	// Update is called once per frame
	void Update () {
		MoveObjectAtRate (m_platforms, m_speed);
	}
	#endregion


	void Setup() {
		GameObject[] platArray = GameObject.FindGameObjectsWithTag ("PlatformBody");
		m_platforms.AddRange(platArray);
		m_endSpawn_X = m_endSpawnGameObject.transform.position.x;
		m_speedChanges = 1;
	}

	#region Movement
	void MoveObjectAtRate(List<GameObject> objects, float speed) {
		foreach(GameObject obj in objects) {
			Vector3 current = obj.transform.position;
			Vector3 destination = new Vector3(m_endSpawn_X, obj.transform.position.y,0);
			obj.transform.position = Vector3.MoveTowards (current, destination, Time.deltaTime * speed * m_speedChanges);
		}
	}	

	public void StopSpeed() {
		m_speedChanges = 0;
	}

	public void PlaySpeed() {
		m_speedChanges = 1;
	}
	#endregion

	#region Platforms
	public void insertPlatform(GameObject obj){
		m_platforms.Add (obj);
	}
	#endregion
}
