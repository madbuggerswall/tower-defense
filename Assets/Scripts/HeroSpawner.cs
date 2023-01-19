using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO Mana mechanics
// TODO Mana mechanics: Enemies reward mana
// TODO Mana mechanics: Each spawned hero increases mana required to spawn a hero
// TODO Projectiles move with dragged heroes
// TODO Stop heroes from firing when dragged
// TODO StatManager

public class HeroSpawner : MonoBehaviour {
	static HeroSpawner instance;

	const int manaIncrement = 10;
	const int initialMana = 60;

	[SerializeField] int manaRequired;
	[SerializeField] int mana;

	ObjectPool objectPool;

	void Awake() {
		assertSingleton();
		objectPool = GetComponentInChildren<ObjectPool>();
	}

	void Start() {
		mana = initialMana;
		manaRequired = manaIncrement;
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
	public void spawnRandomHero() {
		HeroGrid heroGrid = FindObjectOfType<HeroGrid>();
		
		if (mana < manaRequired || heroGrid.isGridFull())
			return;

		mana -= manaRequired;
		Hero hero = spawnRandomHeroAtCell(heroGrid.getRandomCell());
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
}
