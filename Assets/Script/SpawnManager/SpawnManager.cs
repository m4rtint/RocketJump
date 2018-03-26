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


	LinkedList<GameObject> mAvailablePlatforms = new LinkedList<GameObject>();
	LinkedList<GameObject> mPlatformsInMotion = new LinkedList<GameObject> ();

	//Spawn Properties
	float m_spawnAt_X;
	[Header("Spawn Height Difference")]
	[SerializeField]
	float m_Max_y;
	[SerializeField]
	float m_Min_y;
    [SerializeField]
    float m_rangeDifference;


    [Header("Spawn Distance Difference")]
	[SerializeField]
	float m_Max_Dist;
	[SerializeField]
	float m_Min_Dist;
    int m_spawnDistance;


    #region Mono
    void Awake(){
		Setup ();
	}
	
	// Update is called once per frame
	void Update () {
		SpawnWhenEnoughDistance ();
	}

	#endregion

	#region Setup
	//For the Interface
	void Setup() {
		//Add platforms to platforms in motion
		insertSortedArray (mPlatformsInMotion, GameObject.FindGameObjectsWithTag ("PlatformBody"));

		RandomizeSpawnDistance ();
		SetUpEndSpawnDelegate ();
		SetVariables ();
	}

	void SetVariables() {
		m_spawnAt_X = startSpawnGameObject.transform.localPosition.x;
	}

	void insertSortedArray(LinkedList<GameObject> m_list, GameObject[] m_array) {
		for (int i = 0; i < m_array.Length; i++) {
			
			LinkedListNode<GameObject> temp = m_list.First;

			while (temp != null) {
				//If Current node is smaller than this node, place in front.
				float nodeX = temp.Value.transform.position.x;
				float arrayX = m_array [i].transform.position.x;
				if (arrayX < nodeX) {
					m_list.AddBefore (temp,m_array [i]);
					break;
				}
			
				temp = temp.Next;
			}
			if (temp == null) {
				m_list.AddLast (m_array [i]);
			}
		}
	}

	#endregion

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
        //grab last active plat - Height
        float lastPlat = mPlatformsInMotion.Last.Value.transform.position.y;
        int setPosition_Y = 0;


        if (Random.Range(0,10) % 2 == 0)
        {
            //Lower
            setPosition_Y = (int)(lastPlat - m_rangeDifference);
        } else
        {
            //Higher
            setPosition_Y = (int)(lastPlat + m_rangeDifference);
        }
        

        if (setPosition_Y < m_Min_y)
        {
            setPosition_Y = (int)m_Min_y;
        }

        if (setPosition_Y > m_Max_y)
        {
            setPosition_Y = (int)m_Max_y;
        }

		
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
		#if UNITY_EDITOR
		Debug.Log("Before");
		PrintAllLinkedList ();
		#endif

		mPlatformsInMotion.RemoveFirst ();
		mAvailablePlatforms.AddLast (obj);
		obj.SetActive (false);


		#if UNITY_EDITOR
		Debug.Log("After");
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
