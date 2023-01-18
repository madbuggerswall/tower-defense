using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HeroGrid : MonoBehaviour {
	readonly Vector2Int gridSize = new Vector2Int(3, 5);

	Grid grid;
	ObjectPool objectPool;

	Cell[,] cells;

	void Awake() {
		grid = GetComponentInParent<Grid>();
		objectPool = GetComponentInChildren<ObjectPool>();

		initializeCells();
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.H)) {
			spawnRandomHero();
		}
	}

	// Spawns a random hero at an empty space if grid has one
	void spawnRandomHero() {
		if (isGridFull())
			return;

		Hero heroPrefab = Prefabs.getInstance().getHero(HeroType.knight);
		Hero hero = objectPool.spawn(heroPrefab.gameObject).GetComponent<Hero>();
		getRandomCell().setHero(hero);
	}

	// Very manual way of initializing a grid
	void initializeCells() {
		this.cells = new Cell[gridSize.x, gridSize.y];
		Cell[] cells = GetComponentsInChildren<Cell>();

		for (int i = 0; i < gridSize.x; i++) {
			for (int j = 0; j < gridSize.y; j++) {
				this.cells[i, j] = cells[j * gridSize.x + i];
			}
		}
	}

	// Returns if grid is full of heroes
	bool isGridFull() {
		for (int i = 0; i < cells.GetLength(0); i++) {
			for (int j = 0; j < cells.GetLength(1); j++) {
				if (cells[i, j].hero == null)
					return false;
			}
		}
		return true;
	}

	// Get a random empty cell
	Cell getRandomCell() {
		Vector2Int randomIndex;
		do {
			randomIndex = new Vector2Int(Random.Range(0, gridSize.x), Random.Range(0, gridSize.y));
		} while (cells[randomIndex.x, randomIndex.y].hero != null);
		return cells[randomIndex.x, randomIndex.y];
	}

	// Getters
	public Cell[,] getCells() { return cells; }
}


// Grid snapping for drag and drop possible
// Vector3Int gridIndex = grid.WorldToCell(cells[randomIndex.x, randomIndex.y].transform.position);
// Vector3 position = grid.GetCellCenterWorld(gridIndex);