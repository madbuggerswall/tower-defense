using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Prototype/Clone Pattern
public class Prefabs : MonoBehaviour {
	static Prefabs instance;

	[Header("Enemies")]
	[SerializeField] Enemy cyclops;
	[SerializeField] Enemy spider;
	[SerializeField] Enemy ghost;

	[Header("Heroes")]
	[SerializeField] Dwarf dwarf;
	[SerializeField] Knight knight;
	[SerializeField] Archer archer;


	[Header("Projectiles")]
	[SerializeField] Projectile axe;
	[SerializeField] Projectile dagger;
	[SerializeField] Projectile arrow;

	void Awake() {
		assertSingleton();
	}

	public Enemy getEnemy(EnemyType enemyType) {
		switch (enemyType) {
			case EnemyType.cyclops:
				return cyclops;
			case EnemyType.spider:
				return spider;
			case EnemyType.ghost:
				return ghost;
			default:
				return spider;
		}
	}

	public Hero getHero(HeroType heroType) {
		switch (heroType) {
			case HeroType.dwarf:
				return dwarf;
			case HeroType.knight:
				return knight;
			case HeroType.archer:
				return archer;
			default:
				return knight;
		}
	}

	public Hero getHero(int heroType) {
		return getHero((HeroType) heroType);
	}

	public Projectile getProjectile(ProjectileType projectileType) {
		switch (projectileType) {
			case ProjectileType.axe:
				return axe;
			case ProjectileType.dagger:
				return dagger;
			case ProjectileType.arrow:
				return arrow;
			default:
				return dagger;
		}
	}

	// Singleton
	public static Prefabs getInstance() { return instance; }
	void assertSingleton() { if (instance == null) { instance = this; } else { Destroy(gameObject); } }
}
