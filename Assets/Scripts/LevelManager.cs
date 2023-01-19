using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Mediator
public class LevelManager : MonoBehaviour {
	static LevelManager instance;

	EnemyPath enemyPath;
	HeroGrid heroGrid;
	HeroSpawner heroSpawner;
	EnemySpawner enemySpawner;

	StatManager statManager;

	void Awake() {
		// Gamemanager
		Application.targetFrameRate = 60;

		assertSingleton();

		enemyPath = FindObjectOfType<EnemyPath>();
		heroGrid = FindObjectOfType<HeroGrid>();
		heroSpawner = FindObjectOfType<HeroSpawner>();
		enemySpawner = FindObjectOfType<EnemySpawner>();

		statManager = new StatManager();
	}

	// Singleton
	public static LevelManager getInstance() { return instance; }
	void assertSingleton() { if (instance == null) { instance = this; } else { Destroy(gameObject); } }

	public EnemyPath getEnemyPath() { return enemyPath; }
	public HeroGrid getHeroGrid() { return heroGrid; }
	public HeroSpawner getHeroSpawner() { return heroSpawner; }
	public EnemySpawner getEnemySpawner() { return enemySpawner; }

	public StatManager getStatManager() { return statManager; }
}
