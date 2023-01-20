class Cyclops : Enemy {
	const int defaultHealth = 160;
	const int defaultDamage = 4;
	const float defaultSpeed = 0.8f;

	protected override void OnEnable() {
		health = defaultHealth;
		damage = defaultDamage;
		speed = defaultSpeed;
		base.OnEnable();
	}

	protected override int getDefaultHealth() { return defaultHealth; }
	protected override EnemyType getEnemyType() { return EnemyType.cyclops; }
}