using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {
	public Hero hero;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.isTrigger)
			return;
		
		// if (other.gameObject.layer == LayerMask.NameToLayer("Hero"))
		Debug.Log(other.gameObject.name);
	}

	public void setHero(Hero hero) {
		this.hero = hero;
		hero.transform.parent = transform;
		hero.transform.localPosition = Vector3.zero;
	}

	public void removeHero() { hero = null; }
}
