using System.Collections.Generic;

public class WaveContainer {
	Queue<Wave> queue;

	public WaveContainer() {
		initializeWaves();
	}

	void initializeWaves() {
		Wave wave1 = new Wave(4);
		wave1.setEnemies(
			EnemyType.cyclops,
			EnemyType.cyclops,
			EnemyType.cyclops,
			EnemyType.cyclops);

		Wave wave2 = new Wave(4);
		wave2.setEnemies(
			(4, EnemyType.cyclops),
			(8, EnemyType.cyclops));

		queue = new Queue<Wave>();
		queue.Enqueue(wave1);
		queue.Enqueue(wave2);
	}

	public Queue<Wave> getQueue() { return queue; }
}