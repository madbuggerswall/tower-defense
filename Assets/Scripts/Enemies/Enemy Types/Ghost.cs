class Ghost : Enemy {
	const int defaultHealth = 100;
	const int defaultDamage = 2;
	const float defaultSpeed = 1f;

	// Reset poolable object
	protected override void OnEnable() {
		health = defaultHealth;
		damage = defaultDamage;
		speed = defaultSpeed;
		base.OnEnable();
	}

	protected override int getDefaultHealth() { return defaultHealth; }
	protected override EnemyType getEnemyType() { return EnemyType.ghost; }
}