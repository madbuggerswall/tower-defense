using System.Collections.Generic;

// This should be a ScriptableObject
public class WaveContainer {
	Queue<Wave> queue;

	public WaveContainer() {
		initializeWaves();
	}

	// Manual creation of waves. Monsters spawn more frequently as waves proceed
	void initializeWaves() {
		Wave wave1 = new Wave(4f);
		wave1.setEnemies(
			EnemyType.ghost,
			EnemyType.ghost,
			EnemyType.ghost,
			EnemyType.ghost);

		Wave wave2 = new Wave(4f);
		wave2.setEnemies(
			(8, EnemyType.ghost),
			(4, EnemyType.cyclops));

		Wave wave3 = new Wave(4f);
		wave3.setEnemies(
			(4, EnemyType.ghost),
			(4, EnemyType.spider),
			(4, EnemyType.cyclops));

		Wave wave4 = new Wave(4f);
		wave4.setEnemies(
			(8, EnemyType.ghost),
			(4, EnemyType.spider));

		Wave wave5 = new Wave(3.2f);
		wave5.setEnemies(
			(4, EnemyType.ghost),
			(4, EnemyType.spider),
			(4, EnemyType.ghost),
			(4, EnemyType.spider));

		Wave wave6 = new Wave(3.2f);
		wave6.setEnemies(
			(4, EnemyType.ghost),
			(2, EnemyType.cyclops),
			(4, EnemyType.ghost),
			(2, EnemyType.cyclops));


		Wave wave7 = new Wave(3.2f);
		wave7.setEnemies(
			(4, EnemyType.ghost),
			(4, EnemyType.spider),
			(4, EnemyType.ghost),
			(4, EnemyType.spider));

		Wave wave8 = new Wave(3.2f);
		wave8.setEnemies(
			(8, EnemyType.ghost),
			(2, EnemyType.spider),
			(8, EnemyType.ghost),
			(2, EnemyType.spider));

		Wave wave9 = new Wave(2.8f);
		wave9.setEnemies(
			(4, EnemyType.ghost),
			(2, EnemyType.cyclops),
			(4, EnemyType.ghost),
			(2, EnemyType.cyclops));

		Wave wave10 = new Wave(2.8f);
		wave10.setEnemies(
			(6, EnemyType.ghost),
			(2, EnemyType.spider),
			(6, EnemyType.ghost),
			(4, EnemyType.cyclops));

		Wave wave11 = new Wave(2.8f);
		wave11.setEnemies(
			(8, EnemyType.ghost),
			(8, EnemyType.spider),
			(4, EnemyType.cyclops),
			(4, EnemyType.ghost));

		Wave wave12 = new Wave(2.8f);
		wave12.setEnemies(
			(4, EnemyType.cyclops),
			(4, EnemyType.spider),
			(4, EnemyType.cyclops),
			(4, EnemyType.ghost));

		Wave wave13 = new Wave(2.4f);
		wave13.setEnemies(
			(4, EnemyType.ghost),
			(4, EnemyType.spider),
			(4, EnemyType.ghost),
			(4, EnemyType.spider));

		Wave wave14 = new Wave(2.4f);
		wave14.setEnemies(
			(8, EnemyType.ghost),
			(4, EnemyType.cyclops),
			(4, EnemyType.ghost),
			(4, EnemyType.spider));

		Wave wave15 = new Wave(2f);
		wave15.setEnemies(
			(8, EnemyType.ghost),
			(4, EnemyType.cyclops),
			(4, EnemyType.ghost),
			(4, EnemyType.spider));

		Wave wave16 = new Wave(2f);
		wave16.setEnemies(
			(8, EnemyType.ghost),
			(4, EnemyType.cyclops),
			(4, EnemyType.ghost),
			(4, EnemyType.cyclops));

		queue = new Queue<Wave>();
		queue.Enqueue(wave1);
		queue.Enqueue(wave2);
		queue.Enqueue(wave3);
		queue.Enqueue(wave4);
		queue.Enqueue(wave5);
		queue.Enqueue(wave6);
		queue.Enqueue(wave7);
		queue.Enqueue(wave8);
		queue.Enqueue(wave9);
		queue.Enqueue(wave10);
		queue.Enqueue(wave11);
		queue.Enqueue(wave12);
		queue.Enqueue(wave13);
		queue.Enqueue(wave14);
		queue.Enqueue(wave15);
		queue.Enqueue(wave16);

	}

	public Queue<Wave> getQueue() { return queue; }
}