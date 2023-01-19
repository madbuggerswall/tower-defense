using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dwarf : Hero {
	const int defaultDamage = 32;
	const float defaultDamagePeriod = 4;
	const float defaultDamageRadius = 4;

	protected override void OnEnable() {
		base.OnEnable();
		damage = defaultDamage;
		damagePeriod = defaultDamagePeriod;
		damageRadius = defaultDamageRadius;
	}
}