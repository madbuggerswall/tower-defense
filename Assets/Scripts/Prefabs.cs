using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Prototype/Clone Pattern
public class Prefabs : MonoBehaviour {
	static Prefabs instance;

	// Enemies
	[SerializeField] Enemy enemy;

	// Heroes
	[SerializeField] Hero hero;

	// Projectiles
	[SerializeField] Projectile projectile;

	void Awake() {
		assertSingleton();
	}

	public Enemy getEnemy(EnemyType enemyType) {
		switch (enemyType) {
			case EnemyType.cyclops:
				return enemy;

			default:
				return enemy;
		}
	}

	public Hero getHero(HeroType heroType) {
		switch (heroType) {
			case HeroType.knight:
				return hero;

			default:
				return hero;
		}
	}

	public Projectile getProjectile(ProjectileType projectileType) {
		switch (projectileType) {
			case ProjectileType.dagger:
				return projectile;

			default:
				return projectile;
		}
	}

	// Singleton
	public static Prefabs getInstance() { return instance; }
	void assertSingleton() { if (instance == null) { instance = this; } else { Destroy(gameObject); } }
}
