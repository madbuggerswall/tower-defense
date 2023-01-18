using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProjectileType {
	dagger
}

public class Projectile : MonoBehaviour {
	const float maxDelta = 12f;
	[SerializeField] Transform target;

	Rigidbody2D rigidBody;

	void Awake() {
		rigidBody = GetComponent<Rigidbody2D>();
		rigidBody.isKinematic = true;
	}

	void OnEnable() {
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

	public void throwAtTarget(Transform target) {
		this.target = target;
	}

	public Quaternion lookAtTarget(Vector2 direction) {
		return Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
	}
}
