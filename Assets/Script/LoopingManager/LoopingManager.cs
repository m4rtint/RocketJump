using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingManager : MonoBehaviour {
    [Header("Floor Properties")]
    [SerializeField]
    GameObject[] m_floors;
    [SerializeField]
    float m_floorSpeed;

    [Header("cloud Properties")]
    [SerializeField]
    GameObject[] m_cloud;
    [SerializeField]
    float m_cloudSpeed;

    [Header("bushes Properties")]
    [SerializeField]
    GameObject[] m_bushes;
    [SerializeField]
    float m_bushesSpeed;

    [Header("mountain Properties")]
    [SerializeField]
    GameObject[] m_mountain;
    [SerializeField]
    float m_mountainSpeed;


    #region mono
    // Use this for initialization
    void Start () {
        SetSpeedOfObjects(m_floors, m_floorSpeed);
        SetSpeedOfObjects(m_cloud, m_cloudSpeed);
        SetSpeedOfObjects(m_bushes, m_bushesSpeed);
        SetSpeedOfObjects(m_mountain, m_mountainSpeed);

    }

    #endregion


    #region motion
    public void StopAllObjects()
    {
        SetSpeedOfObjects(m_floors,0);
        SetSpeedOfObjects(m_cloud, 0);
        SetSpeedOfObjects(m_bushes, 0);
        SetSpeedOfObjects(m_mountain, 0);
    }

    public void PlayAllObjects()
    {
		if (StateManager.instance.EqualGame())
        {
            SetSpeedOfObjects(m_floors, m_floorSpeed);
            SetSpeedOfObjects(m_cloud, m_cloudSpeed);
            SetSpeedOfObjects(m_bushes, m_bushesSpeed);
            SetSpeedOfObjects(m_mountain, m_mountainSpeed);
        }
    }

    void SetSpeedOfObjects(GameObject[] objs, float speed)
    {
        for (int i = 0; i < objs.Length; i++)
        {
            objs[i].GetComponent<ScrollingObject>().SetScrollingSpeed(speed);
        }
    }
    #endregion

}
