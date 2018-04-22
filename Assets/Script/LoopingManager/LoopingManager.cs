using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingManager : MonoBehaviour {
    [Header("Floor Properties")]
    [SerializeField]
    GameObject[] m_floors;
    [SerializeField]
    float m_floorSpeed;

    [Header("background Properties")]
    [SerializeField]
    GameObject[] m_background;
    [SerializeField]
    float m_backgroundSpeed;


    #region mono
    // Use this for initialization
    void Start () {
        SetSpeedOfObjects(m_floors, m_floorSpeed);
        SetSpeedOfObjects(m_background, m_backgroundSpeed);
    }

#endregion


    #region motion
    public void StopAllObjects()
    {
        SetSpeedOfObjects(m_floors,0);
        SetSpeedOfObjects(m_background, 0);
    }

    public void PlayAllObjects()
    {
		if (StateManager.instance.EqualGame())
        {
            SetSpeedOfObjects(m_floors, m_floorSpeed);
            SetSpeedOfObjects(m_background, m_backgroundSpeed);
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
