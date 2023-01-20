using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO Do more waves 
// TODO Fast forward button

public class HeroSpawner : MonoBehaviour {
	const int manaIncrement = 10;
	const int initialMana = 60;

	[SerializeField] int manaRequired;
	[SerializeField] int mana;

	ObjectPool objectPool;

	void Awake() {
		objectPool = GetComponentInChildren<ObjectPool>();
	}

	void Start() {
		mana = initialMana;
		manaRequired = manaIncrement;

		Events.getInstance().enemyBeaten.AddListener(gainMana);
	}

	// Spawns a random hero if grid has an empty space or spawner has enough mana
	public void spawnRandomHero() {
		HeroGrid heroGrid = LevelManager.getInstance().getHeroGrid();

		if (mana < manaRequired || heroGrid.isGridFull())
			return;

		mana -= manaRequired;
		manaRequired += manaIncrement;

		Hero hero = spawnRandomHeroAtCell(heroGrid.getRandomCell());
		Events.getInstance().heroSpawned.Invoke(hero.getHeroType());
	}

	void gainMana(EnemyType enemyType) {
		switch (enemyType) {
			case EnemyType.cyclops:
				mana += 30;
				break;
			case EnemyType.ghost:
				mana += 20;
				break;
			case EnemyType.spider:
				mana += 10;
				break;
		}
	}

	// Spawns a random hero at cell
	Hero spawnRandomHeroAtCell(Cell cell) {
		Hero heroPrefab = Prefabs.getInstance().getHero(Random.Range(0, 3));
		Hero hero = objectPool.spawn(heroPrefab.gameObject).GetComponent<Hero>();
		cell.setHero(hero);
		return hero;
	}

	// Spawns a random hero at specified level at cell
	public Hero spawnRandomHeroAtCell(Cell cell, int heroLevel) {
		Hero heroPrefab = Prefabs.getInstance().getHero(Random.Range(0, 3));
		Hero hero = objectPool.spawn(heroPrefab.gameObject).GetComponent<Hero>();
		hero.setLevel(heroLevel);
		cell.setHero(hero);
		return hero;
	}

	// Getters
	public int getMana() { return mana; }
	public int getManaRequired() { return manaRequired; }
}
