using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Events {
	static Events instance;

	public UnityEvent<int> waveBegan;
	public UnityEvent<HeroType> heroSpawned;
	public UnityEvent<EnemyType> enemyBeaten;
	public UnityEvent gameOver;

	public Events() {
		waveBegan = new UnityEvent<int>();
		enemyBeaten = new UnityEvent<EnemyType>();
		heroSpawned = new UnityEvent<HeroType>();
		gameOver = new UnityEvent();
	}

	public static Events getInstance() {
		if (instance == null)
			instance = new Events();
		return instance;
	}
}
