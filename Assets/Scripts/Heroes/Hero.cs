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

	bool isEngaging;

	void Start() {
		Events.getInstance().gameOver.AddListener(delegate { gameObject.SetActive(false); });
	}

	// Reset poolable object, it should've been a IPoolable.reset() call.
	protected virtual void OnEnable() {
		isEngaging = false;
		setLevel(1);
		StartCoroutine(checkRadiusPeriodically(damageRadius, 0.2f));
	}

	// Check radius for enemies, sort them by their path progress, make the first one the target
	IEnumerator checkRadiusPeriodically(float radius, float checkPeriod) {
		int layerMask = LayerMask.GetMask("Enemy");
		List<Enemy> enemiesInRange = new List<Enemy>(4);

		while (true) {
			yield return new WaitForSeconds(checkPeriod);

			// Get enemy colliders in range
			Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius, layerMask);

			// Check again if empty
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

	// Attack function could hold sound and particle FX and other behavior
	void attack(Enemy enemy) {
		throwProjectile(enemy);
	}

	// Spawn and throw a projectile, setting its target and damage value
	void throwProjectile(Enemy target) {
		// A global object pool for projectiles, because of performance and parent-transform reasons
		ObjectPool objectPool = ProjectileContainer.getInstance().GetComponentInChildren<ObjectPool>();
		Projectile projectile = objectPool.spawn(projectilePrefab.gameObject, transform.position).GetComponent<Projectile>();
		projectile.throwAtTarget(target, damage);
	}

	IEnumerator attackPeriodically(float period) {
		isEngaging = true;
		MergeController mergeController = GetComponent<MergeController>();
		
		// Attack while target is active, and hero is not being dragged
		while (target != null && target.gameObject.activeInHierarchy && !mergeController.isDragged()) {
			yield return new WaitForSeconds(period);
			attack(target);
		}
		
		target = null;
		isEngaging = false;
	}

	// Each stat buffed 10% for every promotion
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

	// Because propogating a System.Type through a UnityEvent would be ugly
	public abstract HeroType getHeroType();

	public int getLevel() { return level; }
}
