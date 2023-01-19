using System.Collections.Generic;

// This should be a ScriptableObject
public class WaveContainer {
	Queue<Wave> queue;

	public WaveContainer() {
		initializeWaves();
	}

	void initializeWaves() {
		Wave wave1 = new Wave(4);
		wave1.setEnemies(
			EnemyType.spider,
			EnemyType.spider,
			EnemyType.spider,
			EnemyType.spider);

		Wave wave2 = new Wave(4);
		wave2.setEnemies(
			(8, EnemyType.spider),
			(4, EnemyType.cyclops));

		Wave wave3 = new Wave(4);
		wave3.setEnemies(
			(4, EnemyType.spider),
			(4, EnemyType.ghost),
			(4, EnemyType.cyclops));

		Wave wave4 = new Wave(3.2f);
		wave4.setEnemies(
			(8, EnemyType.spider),
			(4, EnemyType.ghost));

		Wave wave5 = new Wave(3.2f);
		wave5.setEnemies(
			(4, EnemyType.spider),
			(4, EnemyType.ghost),
			(4, EnemyType.spider),
			(4, EnemyType.ghost));

		Wave wave6 = new Wave(3.2f);
		wave6.setEnemies(
			(4, EnemyType.spider),
			(2, EnemyType.cyclops),
			(4, EnemyType.spider),
			(2, EnemyType.cyclops));

		queue = new Queue<Wave>();
		queue.Enqueue(wave1);
		queue.Enqueue(wave2);
		queue.Enqueue(wave3);
		queue.Enqueue(wave4);
		queue.Enqueue(wave5);
		queue.Enqueue(wave6);
	}

	public Queue<Wave> getQueue() { return queue; }
}