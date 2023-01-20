using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileContainer : MonoBehaviour {
	static ProjectileContainer instance;

	ObjectPool objectPool;

	void Awake() {
		assertSingleton();

		objectPool = GetComponentInChildren<ObjectPool>();
	}

	public bool isEmpty() { return (transform.childCount == 0); }

	// Singleton
	public static ProjectileContainer getInstance() { return instance; }
	void assertSingleton() { if (instance == null) { instance = this; } else { Destroy(gameObject); } }
}
