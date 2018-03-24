using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour {



	List<GameObject> m_platforms = new List<GameObject>();

	[SerializeField]
	float m_speed;

	[SerializeField]
	GameObject m_endSpawnGameObject;
	float m_endSpawn_X;

	#region Mono
	void Awake() {
		GameObject[] platArray = GameObject.FindGameObjectsWithTag ("PlatformBody");
		m_platforms.AddRange(platArray);
		m_endSpawn_X = m_endSpawnGameObject.transform.position.x;
	}

	// Update is called once per frame
	void Update () {
		MoveObjectAtRate (m_platforms, m_speed);
	}
	#endregion

	#region Movement
	void MoveObjectAtRate(List<GameObject> objects, float speed) {
		foreach(GameObject obj in objects) {
			Vector3 current = obj.transform.position;
			Vector3 destination = new Vector3(m_endSpawn_X, obj.transform.position.y,0);
			obj.transform.position = Vector3.MoveTowards (current, destination, Time.deltaTime * speed);
		}
	}	
	#endregion

	#region Platforms
	public void insertPlatform(GameObject obj){
		m_platforms.Add (obj);
	}
	#endregion
}
