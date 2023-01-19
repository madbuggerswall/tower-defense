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
	Enemy target;

	void Update() {
		if (!target.gameObject.activeInHierarchy)
			gameObject.SetActive(false);

		if (transform.position == target.transform.position) {
			target.takeDamage(damage);
			gameObject.SetActive(false);
		}

		moveTowardsTarget(target.transform.position);
	}

	void moveTowardsTarget(Vector3 targetPosition) {
		Vector3 towardsPosition = Vector3.MoveTowards(transform.position, targetPosition, maxDelta * Time.deltaTime);
		transform.position = towardsPosition;
		transform.up = targetPosition - transform.position;
	}

	public void throwAtTarget(Enemy target, int damage) {
		this.target = target;
		this.damage = damage;
	}

	// Getters
	public int getDamage() { return damage; }
}
