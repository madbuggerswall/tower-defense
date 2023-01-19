using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Hero {
	const int defaultDamage = 4;
	const float defaultDamagePeriod = 2;
	const float defaultDamageRadius = 12;

	void OnEnable() {
		damage = defaultDamage;
		damagePeriod = defaultDamagePeriod;
		damageRadius = defaultDamageRadius;
	}
}
