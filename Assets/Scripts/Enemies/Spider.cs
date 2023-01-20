class Spider : Enemy {
	const int defaultHealth = 80;
	const int defaultDamage = 1;
	const float defaultSpeed = 1.6f;

	protected override void OnEnable() {
		health = defaultHealth;
		damage = defaultDamage;
		speed = defaultSpeed;
		base.OnEnable();
	}

	protected override int getDefaultHealth() { return defaultHealth; }
	protected override EnemyType getEnemyType() { return EnemyType.spider; }

}