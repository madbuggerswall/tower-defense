using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Hero {
	const int defaultDamage = 4;
	const float defaultDamagePeriod = 1.2f;
	const float defaultDamageRadius = 12;

	protected override void OnEnable() {
		base.OnEnable();
		damage = defaultDamage;
		damagePeriod = defaultDamagePeriod;
		damageRadius = defaultDamageRadius;
	}

	public override HeroType getHeroType() { return HeroType.archer; }
}
