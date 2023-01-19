using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSpawner : MonoBehaviour {
	static HeroSpawner instance;

	[SerializeField] int manaRequired;
	[SerializeField] int mana;

	ObjectPool objectPool;

	void Awake() {
		assertSingleton();
		objectPool = GetComponentInChildren<ObjectPool>();
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.H)) {
			spawnRandomHero();
		}
	}

	// Singleton
	public static HeroSpawner getInstance() { return instance; }
	void assertSingleton() { if (instance == null) { instance = this; } else { Destroy(gameObject); } }

	// Spawns a random hero at an empty space if grid has one
	void spawnRandomHero() {
		HeroGrid heroGrid = FindObjectOfType<HeroGrid>();
		if (heroGrid.isGridFull())
			return;

		spawnRandomHeroAtCell(heroGrid.getRandomCell());
	}

	void spawnRandomHeroAtCell(Cell cell) {
		Hero heroPrefab = Prefabs.getInstance().getHero(Random.Range(0, 3));
		Hero hero = objectPool.spawn(heroPrefab.gameObject).GetComponent<Hero>();
		cell.setHero(hero);
	}

	public void spawnRandomHeroAtCell(Cell cell, int heroLevel) {
		Hero heroPrefab = Prefabs.getInstance().getHero(Random.Range(0, 3));
		Hero hero = objectPool.spawn(heroPrefab.gameObject).GetComponent<Hero>();
		hero.setLevel(heroLevel);
		cell.setHero(hero);
	}
}
