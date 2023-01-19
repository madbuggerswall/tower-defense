using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Dwarf:		high period, high damage, regular range
// Knight:	regular period, regular damage, regular range
// Archer:	regular period, low damage, high range

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
		isEngaging = false;
		objectPool = GetComponentInChildren<ObjectPool>();
	}

	void Start() {
		StartCoroutine(checkRadiusPeriodically(damageRadius, 0.2f));
	}

	protected virtual void OnEnable() {
		setLevel(1);
	}

	// Break down this abomination of a function
	IEnumerator checkRadiusPeriodically(float radius, float checkPeriod) {
		// Overlap circle boilerplate
		int layerMask = LayerMask.GetMask("Enemy");
		Collider2D[] colliders = new Collider2D[4];
		ContactFilter2D contactFilter = new ContactFilter2D();
		contactFilter.SetLayerMask(layerMask);

		List<Enemy> enemiesInRange = new List<Enemy>(4);

		while (true) {
			yield return new WaitForSeconds(checkPeriod);

			// Get enemy colliders in range
			int enemiesDetected = Physics2D.OverlapCircle(transform.position, radius, contactFilter, colliders);
			if (enemiesDetected == 0)
				continue;

			// Add detected enemies to a list to be sorted
			for (int i = 0; i < enemiesDetected; i++) {
				Enemy enemy = colliders[i].GetComponent<Enemy>();
				enemiesInRange.Add(enemy);
			}

			// Sort detected enemies by path percentage, make the first the target
			enemiesInRange.Sort((first, second) => second.getPathPercentage().CompareTo(first.getPathPercentage()));
			target = enemiesInRange[0];
			enemiesInRange.Clear();

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
		projectile.throwAtTarget(target.transform, damage);
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
