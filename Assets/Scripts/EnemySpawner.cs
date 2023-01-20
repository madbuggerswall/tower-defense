using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	const float waveBreak = 2f;

	WaveContainer waveContainer;
	ObjectPool objectPool;

	void Awake() {
		waveContainer = new WaveContainer();
		objectPool = GetComponentInChildren<ObjectPool>();
	}

	void Start() {
		Events.getInstance().gameOver.AddListener(delegate { StopAllCoroutines(); });
		StartCoroutine(spawnWaves(waveContainer));
	}

	IEnumerator spawnWaves(WaveContainer waveContainer) {
		int waveCount = 1;

		Queue<Wave> waveQueue = waveContainer.getQueue();
		while (waveQueue.Count > 0) {
			Events.getInstance().waveBegan.Invoke(waveCount++);
			yield return new WaitForSeconds(waveBreak);
			yield return spawnEnemies(waveQueue.Dequeue());
		}
	}

	IEnumerator spawnEnemies(Wave wave) {
		Queue<EnemyType> enemyQueue = wave.getEnemyQueue();

		while (enemyQueue.Count > 0) {
			Enemy enemyPrefab = Prefabs.getInstance().getEnemy(enemyQueue.Dequeue());
			objectPool.spawn(enemyPrefab.gameObject, transform.position);
			yield return new WaitForSeconds(wave.getPeriod());
		}
	}

}
