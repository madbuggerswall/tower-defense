using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dwarf : Hero {
	const int defaultDamage = 32;
	const float defaultDamagePeriod = 4f;
	const float defaultDamageRadius = 4;

	// Reset poolable object
	protected override void OnEnable() {
		base.OnEnable();
		damage = defaultDamage;
		damagePeriod = defaultDamagePeriod;
		damageRadius = defaultDamageRadius;
	}

	public override HeroType getHeroType() { return HeroType.dwarf; }
}
