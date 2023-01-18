using System.Collections.Generic;
using UnityEngine;
using System;

public enum EnemyType {
	cyclops
}

// DO NOT introduce generic type names such as Element, Node, Log, and Message [learn.microsoft suggests]
// Rename this to EnemyWave

public class Wave {
	float period;
	Queue<EnemyType> enemyQueue;

	public Wave(float period) {
		this.period = period;
		enemyQueue = new Queue<EnemyType>();
	}

	public void setEnemies(params EnemyType[] enemyQueue) {
		foreach (EnemyType enemy in enemyQueue) {
			this.enemyQueue.Enqueue(enemy);
		}
	}

	public void setEnemies(params (int, EnemyType)[] enemyEntries) {
		foreach ((int count, EnemyType type) enemyEntry in enemyEntries) {
			for (int i = 0; i < enemyEntry.count; i++) {
				enemyQueue.Enqueue(enemyEntry.type);
			}
		}
	}

	public float getPeriod() { return period; }
	public Queue<EnemyType> getEnemyQueue() { return enemyQueue; }
}
