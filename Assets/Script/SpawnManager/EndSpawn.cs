﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class EndSpawn : MonoBehaviour {

	//Delegate
	public delegate void PlatformReachedEnd(GameObject obj);
	public PlatformReachedEnd OnPlatformEnter;

	void OnTriggerEnter2D(Collider2D other) {
		OnPlatformEnter(other.gameObject.transform.parent.gameObject);
	}
		
}