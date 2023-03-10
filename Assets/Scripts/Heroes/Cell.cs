using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// HeroGrid consists of Cells, Cells can hold heroes
public class Cell : MonoBehaviour {
	public Hero hero;

	public void setHero(Hero hero) {
		this.hero = hero;
		hero.transform.parent = transform;
		hero.transform.localPosition = Vector3.zero;
	}

	public void removeHero() {
		hero.transform.parent = LevelManager.getInstance().getHeroSpawner().GetComponentInChildren<ObjectPool>().transform;
		hero.gameObject.SetActive(false);
		hero = null;
	}
}
