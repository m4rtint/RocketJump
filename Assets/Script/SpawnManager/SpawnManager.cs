using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
	[SerializeField]
	GameObject startSpawnGameObject;
	[SerializeField]
	GameObject endSpawnGameObject;
	[SerializeField]
	GameObject[] loadedPlatforms;

	GameObject[] m_platforms;

	LinkedList<GameObject> mAvailablePlatforms = new LinkedList<GameObject>();
	LinkedList<GameObject> mPlatformsInMotion = new LinkedList<GameObject> ();

	//Spawn Properties
	float m_spawnAt_X;
	int m_spawnDistance;
	[Header("Spawn Height Difference")]
	[SerializeField]
	float m_Max_y;
	[SerializeField]
	float m_Min_y;

	[Header("Spawn Distance Difference")]
	[SerializeField]
	float m_Max_Dist;
	[SerializeField]
	float m_Min_Dist;

	#region Mono
	void Awake(){
		m_platforms = GameObject.FindGameObjectsWithTag ("PlatformBody");
		Setup ();

	}
	
	// Update is called once per frame
	void Update () {
		SpawnWhenEnoughDistance ();
	}

	#endregion

	//For the Interface
	void Setup() {
		//Add platforms to platforms in motion
		for (int i = 0; i < m_platforms.Length; i++) {
			mPlatformsInMotion.AddLast (m_platforms[i]);
		}
		RandomizeSpawnDistance ();
		SetUpEndSpawnDelegate ();
		SetVariables ();
	}

	void SetVariables() {
		m_spawnAt_X = startSpawnGameObject.transform.localPosition.x;
	}


	#region Spawn
	void SpawnWhenEnoughDistance() {
		if (IsSpawnDistanceFarEnough()) {
			SpawnPlatform ();
			RandomizeSpawnDistance ();
		}
	}

	bool IsSpawnDistanceFarEnough(){
		GameObject lastPlatform = mPlatformsInMotion.Last.Value;
		float diffPosition = startSpawnGameObject.transform.position.x - lastPlatform.transform.position.x ;
		return diffPosition >= m_spawnDistance;
	}
		
	void SpawnPlatform() {

		GameObject platform = null;
		if (mAvailablePlatforms.Count == 0) {
			//Instantiate
			platform = Instantiate (GetRandomPlatform(),gameObject.transform);
			GetComponent<MovementManager> ().insertPlatform (platform);
		} else {
			// Get the platform from availablePlatform
			platform = mAvailablePlatforms.First.Value;
			//Add/remove from corresponding list
			mAvailablePlatforms.RemoveFirst();
		}

		//Set Platform position
		SetPlatformPosition(platform);

		//Platform now in motion
		mPlatformsInMotion.AddLast (platform);
		platform.SetActive (true);
	
	}

	GameObject GetRandomPlatform(){
		int index = Random.Range (0, loadedPlatforms.Length);
		return loadedPlatforms [index];
	}

	void SetPlatformPosition(GameObject plat) {
		int setPosition_Y = (int)Random.Range (m_Min_y, m_Max_y);
		plat.transform.position = new Vector3(m_spawnAt_X, setPosition_Y, 0);
	}

	void RandomizeSpawnDistance() {
		//Spawn Distance
		m_spawnDistance = (int)Random.Range (m_Min_Dist, m_Max_Dist);
	}

	#endregion



	#region Delegate

	void SetUpEndSpawnDelegate(){
		endSpawnGameObject.GetComponent<EndSpawn> ().OnPlatformEnter += PlatformEnteredEnd;
	}

	void PlatformEnteredEnd(GameObject obj){
		mPlatformsInMotion.RemoveFirst ();
		mAvailablePlatforms.AddLast (obj);
		obj.SetActive (false);

		#if UNITY_EDITOR
		PrintAllLinkedList ();
		#endif
	}


	#endregion

	#region DEBUG
	#if UNITY_EDITOR

	void PrintAllLinkedList() {
		PrintLinkedList (mAvailablePlatforms.First, "Available Platforms");
		PrintLinkedList (mPlatformsInMotion.First, "Motion Platforms");
		Debug.Log ("@@@@@@@@@@@@@@@@@@");
	}

	void PrintLinkedList(LinkedListNode<GameObject> node, string NameOfList) {
		string list = NameOfList;
		LinkedListNode<GameObject> temp = node;
		while (temp != null) {
			string name = temp.Value.name;
			list = list+"<-"+name;
			temp = temp.Next;
		}
		Debug.Log (list);
	}
	#endif
	#endregion
}
