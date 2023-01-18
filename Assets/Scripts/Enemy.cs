using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	const int maxHealth = 100;

	[SerializeField] int health;
	[SerializeField] float speed;
	[SerializeField] float pathPercentage;

	[SerializeField] Transform healthBar;

	Rigidbody2D rigidBody;

	// This should not be referenced
	EnemyPath enemyPath;
	int targetIndex = 0;


	void Awake() {
		enemyPath = FindObjectOfType<EnemyPath>();

		rigidBody = GetComponent<Rigidbody2D>();

		rigidBody.isKinematic = true;
	}

	// ObjectPool, IPoolable.Reset
	void OnEnable() {
		health = maxHealth;
		pathPercentage = 0;
		targetIndex = 0;

		updateHealthBar();
	}

	void FixedUpdate() {
		// moveAlongPath(enemyPath);
		moveTowardsNodes();
	}

	// Lerp along path, like a spline.
	void moveAlongPath(EnemyPath path) {
		pathPercentage += speed / enemyPath.getLength() * Time.deltaTime;
		rigidBody.MovePosition(enemyPath.getPosition(pathPercentage));
	}

	// Botched but more performant movement, requires targetIndex
	void moveTowardsNodes() {
		if (targetIndex >= enemyPath.getNodes().Length)
			return;

		if (rigidBody.position != (Vector2) enemyPath.getNodes()[targetIndex].position) {
			Vector2 target = enemyPath.getNodes()[targetIndex].position;
			rigidBody.MovePosition(Vector3.MoveTowards(rigidBody.position, target, speed * Time.fixedDeltaTime));
		} else {
			targetIndex++;
		}
	}

	void updateHealthBar() {
		float barScale = Mathf.Clamp((float) health / maxHealth, 0, maxHealth);
		healthBar.localScale = new Vector3(barScale, 1, 1);
	}

	public bool takeDamage(int damage) {
		health -= damage;
		updateHealthBar();

		if (health <= 0) {
			gameObject.SetActive(false);
			return true;
		} else {
			return false;
		}
	}
}
