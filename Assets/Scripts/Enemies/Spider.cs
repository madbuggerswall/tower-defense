class Spider : Enemy {
	const int defaultHealth = 80;
	const float defaultSpeed = 1.6f;

	protected override void OnEnable() {
		health = defaultHealth;
		speed = defaultSpeed;
		base.OnEnable();
	}

	protected override int getDefaultHealth() { return defaultHealth; }
	protected override EnemyType getEnemyType() { return EnemyType.spider; }

}