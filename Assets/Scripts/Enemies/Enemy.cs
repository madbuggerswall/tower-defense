using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Cyclops: slow and strong
// Spider: balanced
// ghost: fast and weakz

public enum EnemyType {
	cyclops,
	spider,
	ghost
}

public abstract class Enemy : MonoBehaviour {
	[SerializeField] protected int health;
	[SerializeField] protected int damage;
	[SerializeField] protected float speed;
	[SerializeField] float pathPercentage;

	[SerializeField] Transform healthBar;

	Rigidbody2D rigidBody;

	UnityAction movementAction;

	void Awake() {
		rigidBody = GetComponent<Rigidbody2D>();
		rigidBody.isKinematic = true;
	}

	// ObjectPool, IPoolable.Reset
	protected virtual void OnEnable() {
		pathPercentage = 0;
		movementAction = delegate { moveAlongPath(LevelManager.getInstance().getEnemyPath()); };
		updateHealthBar();
	}

	void FixedUpdate() {
		movementAction();
	}

	// Lerp along path, like a spline.
	void moveAlongPath(EnemyPath path) {
		pathPercentage += speed / path.getLength() * Time.deltaTime;
		rigidBody.MovePosition(path.getPosition(pathPercentage));

		if (pathPercentage >= 1) {
			StartCoroutine(attackPeriodically(1f));
			movementAction = delegate { };
		}
	}

	void updateHealthBar() {
		float barScale = Mathf.Clamp((float) health / getDefaultHealth(), 0, getDefaultHealth());
		healthBar.localScale = new Vector3(barScale, 1, 1);
	}

	public void takeDamage(int damage) {
		health -= damage;
		updateHealthBar();

		if (health <= 0) {
			gameObject.SetActive(false);
			Events.getInstance().enemyBeaten.Invoke(getEnemyType());
		}
	}

	IEnumerator attackPeriodically(float period) {
		Princess princess = LevelManager.getInstance().getPrincess();
		while (true) {
			princess.takeDamage(damage);
			yield return new WaitForSeconds(period);
		}
	}

	// Getters
	protected abstract int getDefaultHealth();
	protected abstract EnemyType getEnemyType();

	public float getPathPercentage() { return pathPercentage; }
}
