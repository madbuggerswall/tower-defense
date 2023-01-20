using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Princess : MonoBehaviour {
	const int maxHealth = 100;
	[SerializeField] int health;
	[SerializeField] Transform healthBar;

	void updateHealthBar() {
		float barScale = Mathf.Clamp((float) health / maxHealth, 0, maxHealth);
		healthBar.localScale = new Vector3(barScale, 1, 1);
	}

	public void takeDamage(int damage) {
		health -= damage;
		updateHealthBar();

		if (health <= 0) {
			// Game Over
		}
	}
}
