using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlatformOrigin : MonoBehaviour {

    [SerializeField]
    Sprite[] platforms;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "EndSpawn")
        {
            GetComponent<SpriteRenderer>().sprite = RandomizePlatform(); 
        }
    }

    Sprite RandomizePlatform()
    {
        int index = Random.Range(0, platforms.Length);
        return platforms[index];
    }
}
