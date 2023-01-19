using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProjectileType {
	axe,
	dagger,
	arrow
}

public class Projectile : MonoBehaviour {
	const float maxDelta = 12f;

	int damage = 10;

	Transform target;
	Rigidbody2D rigidBody;

	void Awake() {
		rigidBody = GetComponent<Rigidbody2D>();
		rigidBody.isKinematic = true;
	}

	void Update() {
		if (!target.gameObject.activeInHierarchy)
			gameObject.SetActive(false);
	}

	void FixedUpdate() {
		Vector3 targetPosition = Vector3.MoveTowards(rigidBody.position, target.position, maxDelta * Time.fixedDeltaTime);
		transform.up = target.position - transform.position;
		rigidBody.MovePosition(targetPosition);
	}

	void OnCollisionEnter2D(Collision2D other) {
		gameObject.SetActive(false);
	}

	public void throwAtTarget(Transform target, int damage) {
		this.target = target;
		this.damage = damage;
	}

	// Getters
	public int getDamage() { return damage; }
}
