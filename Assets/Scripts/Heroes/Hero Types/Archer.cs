using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Hero {
	const int defaultDamage = 6;
	const float defaultDamagePeriod = 2f;
	const float defaultDamageRadius = 12;

	// Reset poolable object
	protected override void OnEnable() {
		base.OnEnable();
		damage = defaultDamage;
		damagePeriod = defaultDamagePeriod;
		damageRadius = defaultDamageRadius;
	}

	public override HeroType getHeroType() { return HeroType.archer; }
}
