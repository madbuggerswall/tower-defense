using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Dwarf:		Damage: 32 | Period: 4 | Radius: 4
// Knight:	Damage: 10 | Period: 1 | Radius: 4
// Archer:	Damage: 4	 | Period: 2 | Radius: 12


public enum HeroType {
	dwarf,
	knight,
	archer
}

public abstract class Hero : MonoBehaviour {
	[Header("Hero Properties")]
	[SerializeField] int level = 1;
	[SerializeField] Projectile projectilePrefab;

	[Header("Damage Properties")]
	[SerializeField] protected int damage = 10;
	[SerializeField] protected float damagePeriod = 1;
	[SerializeField] protected float damageRadius = 4;

	Enemy target;
	ObjectPool objectPool;

	bool isEngaging;

	void Awake() {
		objectPool = GetComponentInChildren<ObjectPool>();
	}

	// IPoolable.reset()
	protected virtual void OnEnable() {
		isEngaging = false;
		setLevel(1);
		StartCoroutine(checkRadiusPeriodically(damageRadius, 0.2f));
	}

	// Break down this abomination of a function
	IEnumerator checkRadiusPeriodically(float radius, float checkPeriod) {
		int layerMask = LayerMask.GetMask("Enemy");
		List<Enemy> enemiesInRange = new List<Enemy>(4);

		while (true) {
			yield return new WaitForSeconds(checkPeriod);

			// Get enemy colliders in range
			Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius, layerMask);

			// Checl again if empty
			if (colliders.Length == 0)
				continue;
			// Add detected enemies to a list to be sorted
			for (int i = 0; i < colliders.Length; i++)
				enemiesInRange.Add(colliders[i].GetComponent<Enemy>());

			// Sort detected enemies by path percentage, make the first one the target
			enemiesInRange.Sort((first, second) => second.getPathPercentage().CompareTo(first.getPathPercentage()));
			target = enemiesInRange[0];
			enemiesInRange.Clear();

			// Start firing if it isn't already
			if (!isEngaging)
				StartCoroutine(attackPeriodically(damagePeriod));
		}
	}

	// Damage enemy and throw a projectile as a visual aid
	void attack(Enemy enemy) {
		throwProjectile(enemy);
	}

	// No collision damage, just as a visual effect.
	void throwProjectile(Enemy target) {
		Projectile projectile = objectPool.spawn(projectilePrefab.gameObject, transform.position).GetComponent<Projectile>();
		projectile.throwAtTarget(target, damage);
	}

	IEnumerator attackPeriodically(float period) {
		isEngaging = true;
		while (target != null && target.gameObject.activeInHierarchy) {
			yield return new WaitForSeconds(period);
			attack(target);
		}
		target = null;
		isEngaging = false;
	}

	// Each stat buffed 10%
	public void setLevel(int level) {
		for (int i = this.level; i < level; i++) {
			damage += Mathf.CeilToInt(damage * 0.1f);
			damagePeriod -= damagePeriod * 0.1f;
			damageRadius += damageRadius * 0.1f;
		}

		// Update Hero UI
		this.level = level;
		GetComponentInChildren<UnityEngine.UI.Text>().text = level.ToString();
	}

	// Getters
	public int getLevel() { return level; }
}
