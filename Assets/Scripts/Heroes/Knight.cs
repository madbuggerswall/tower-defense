using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Hero {
	const int defaultDamage = 10;
	const float defaultDamagePeriod = 1;
	const float defaultDamageRadius = 4;

	protected override void OnEnable() {
		base.OnEnable();
		damage = defaultDamage;
		damagePeriod = defaultDamagePeriod;
		damageRadius = defaultDamageRadius;
	}

	public override HeroType getHeroType() { return HeroType.knight; }
}
