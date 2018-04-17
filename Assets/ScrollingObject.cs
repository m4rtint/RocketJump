using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class ScrollingObject : MonoBehaviour {

    //Reposition properties
    BoxCollider2D m_groundCollider;
    float m_groundHorizontalLength;

    //Scrolling Properties
    Rigidbody2D m_rigidBody;
    float m_speed;

    // Use this for initialization
    #region Mono
    void Awake () {
        m_rigidBody = GetComponent<Rigidbody2D>();
        m_groundCollider = GetComponent<BoxCollider2D>();
        m_groundHorizontalLength = m_groundCollider.size.x;
        m_rigidBody.bodyType = RigidbodyType2D.Kinematic;
	}

    void Update()
    {
       if (transform.position.x < -m_groundHorizontalLength)
        {
            RepositionBackground();
        }
    }

    #endregion

    #region Scrolling


    public void SetScrollingSpeed(float speed)
    {
        m_speed = speed;
        m_rigidBody.velocity = new Vector2(-speed, 0);
    }
    #endregion

    #region Reposition
    private void RepositionBackground()
    {
        Vector2 groundOffSet = new Vector2(m_groundHorizontalLength * 2f, 0);
        transform.position = (Vector2)transform.position + groundOffSet;
    }

    #endregion


}
