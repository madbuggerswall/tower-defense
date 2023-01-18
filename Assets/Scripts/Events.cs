using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Events {
	static Events instance;

	public UnityEvent<int> waveBegan;
	public UnityEvent enemyKilled;

	public Events() {
		enemyKilled = new UnityEvent();
		waveBegan = new UnityEvent<int>();
	}

	public static Events getInstance() {
		if (instance == null)
			instance = new Events();
		return instance;
	}
}
