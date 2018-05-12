using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlatformOrigin : MonoBehaviour {

    [SerializeField]
    Sprite[] platforms;

    [SerializeField]
    GameObject m_PlatformObject;
    [SerializeField]
    GameObject m_PlatformOriginObject;

    BoxCollider2D[] m_Colliders;

    bool originalPassby = true;

    private void Awake()
    {
        m_Colliders = new BoxCollider2D[] { m_PlatformObject.GetComponent<BoxCollider2D>(), m_PlatformOriginObject.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>() };
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "EndSpawn")
        {
            GetComponent<SpriteRenderer>().sprite = RandomizePlatform();

            if (originalPassby)
            {
                for(int i = 0; i < m_Colliders.Length; i++) {
                    Vector2 currentOffset = m_Colliders[i].offset;
                    m_Colliders[i].offset = currentOffset + new Vector2(0, 0.25f);
                    originalPassby = false;
                }
            }

        }
    }

    Sprite RandomizePlatform()
    {
        int index = Random.Range(0, platforms.Length);
        return platforms[index];
    }
}
