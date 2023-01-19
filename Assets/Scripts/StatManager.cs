using UnityEngine;

[System.Serializable]
class StatManager {
	const int cyclopsScore = 30;
	const int ghostScore = 20;
	const int spiderScore = 10;

	[SerializeField] int cyclopsesBeaten;
	[SerializeField] int ghostsBeaten;
	[SerializeField] int spidersBeaten;

	[SerializeField] int dwarfSpawned;
	[SerializeField] int knightSpawned;
	[SerializeField] int archerSpawned;

	[SerializeField] int score;

	public StatManager() {
		Events.getInstance().enemyBeaten.AddListener(onEnemyBeaten);
		Events.getInstance().heroSpawned.AddListener(onHeroSpawned);
	}

	void onEnemyBeaten(EnemyType enemyType) {
		switch (enemyType) {
			case EnemyType.cyclops:
				cyclopsesBeaten++;
				score += cyclopsScore;
				break;
			case EnemyType.ghost:
				ghostsBeaten++;
				score += ghostScore;
				break;
			case EnemyType.spider:
				spidersBeaten++;
				score += spiderScore;
				break;
			default:
				score += spiderScore;
				break;
		}
	}

	void onHeroSpawned(HeroType heroType) {
		switch (heroType) {
			case HeroType.dwarf:
				dwarfSpawned++;
				break;
			case HeroType.knight:
				knightSpawned++;
				break;
			case HeroType.archer:
				archerSpawned++;
				break;
		}
	}
}