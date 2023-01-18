using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HeroType {
	knight
}

public class Hero : MonoBehaviour {

	[SerializeField] int damage;
	[SerializeField] float damagePeriod;
	[SerializeField] float damageRadius;

	[SerializeField] List<Enemy> targets;

	CircleCollider2D circleCollider;

	ObjectPool objectPool;

	void Awake() {
		targets = new List<Enemy>();

		objectPool = GetComponentInChildren<ObjectPool>();
		circleCollider = GetComponent<CircleCollider2D>();

		circleCollider.radius = damageRadius;

	}

	// OnTrigger funtions don't respect Layer Collision Matrix
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.layer != LayerMask.NameToLayer("Enemy"))
			return;

		targets.Add(other.GetComponent<Enemy>());
		if (targets.Count < 2) {
			StartCoroutine(attackPeriodically(damagePeriod));
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		targets.Remove(other.GetComponent<Enemy>());
	}

	void OnMouseDown() {
		circleCollider.enabled = false;
	}

	// Merge movement
	void OnMouseDrag() {
		Vector3 mouseWorldPos = getMouseWorldPos();
		transform.position = new Vector3(mouseWorldPos.x, mouseWorldPos.y, 0);
	}

	void OnMouseUp() {
		// If merge is invalid return to initial position
		circleCollider.enabled = true;
	}

	Vector3 getMouseWorldPos() {
		float mousePosX = Mathf.Clamp(Input.mousePosition.x, 0, Screen.width);
		float mousePosY = Mathf.Clamp(Input.mousePosition.y, 0, Screen.height);

		return Camera.main.ScreenToWorldPoint(new Vector3(mousePosX, mousePosY, 0));
	}

	void attack(Enemy enemy) {
		enemy.takeDamage(damage);
		throwProjectile(enemy);
	}

	// No collision damage, just as a visual effect.
	void throwProjectile(Enemy target) {
		Projectile daggerPrefab = Prefabs.getInstance().getProjectile(ProjectileType.dagger);
		Projectile dagger = objectPool.spawn(daggerPrefab.gameObject, transform.position).GetComponent<Projectile>();
		dagger.throwAtTarget(target.transform);
	}

	IEnumerator attackPeriodically(float period) {
		while (targets.Count > 0) {
			attack(targets[0]);
			yield return new WaitForSeconds(period);
		}
	}
}
