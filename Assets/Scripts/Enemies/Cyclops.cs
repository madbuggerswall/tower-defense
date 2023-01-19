class Cyclops : Enemy {
	const int defaultHealth = 160;
	const float defaultSpeed = 1;

	protected override void OnEnable() {
		health = defaultHealth;
		speed = defaultSpeed;
		base.OnEnable();
	}

	protected override int getDefaultHealth() { return defaultHealth; }
	protected override EnemyType getEnemyType() { return EnemyType.cyclops; }
}