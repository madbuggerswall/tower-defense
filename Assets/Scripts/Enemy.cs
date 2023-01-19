using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Cyclops: slow and strong
// Spider: balanced
// ghost: fast and weakz

public enum EnemyType {
	cyclops,
	spider,
	ghost
}

public class Enemy : MonoBehaviour {
	const int maxHealth = 100;

	[SerializeField] int health;
	[SerializeField] float speed;
	[SerializeField] float pathPercentage;

	[SerializeField] Transform healthBar;

	Rigidbody2D rigidBody;

	void Awake() {
		rigidBody = GetComponent<Rigidbody2D>();
		rigidBody.isKinematic = true;
	}

	// ObjectPool, IPoolable.Reset
	void OnEnable() {
		health = maxHealth;
		pathPercentage = 0;

		updateHealthBar();
	}

	void FixedUpdate() {
		moveAlongPath(EnemyPath.getInstance());
	}

	void OnCollisionEnter2D(Collision2D other) {
		takeDamage(other.gameObject.GetComponent<Projectile>().getDamage());
	}

	// Lerp along path, like a spline.
	void moveAlongPath(EnemyPath path) {
		pathPercentage += speed / path.getLength() * Time.deltaTime;
		rigidBody.MovePosition(path.getPosition(pathPercentage));
	}

	void updateHealthBar() {
		float barScale = Mathf.Clamp((float) health / maxHealth, 0, maxHealth);
		healthBar.localScale = new Vector3(barScale, 1, 1);
	}

	public void takeDamage(int damage) {
		health -= damage;
		updateHealthBar();

		if (health <= 0)
			gameObject.SetActive(false);
	}

	public float getPathPercentage() { return pathPercentage; }
}
