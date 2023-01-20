using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeController : MonoBehaviour {
	[SerializeField] Hero mergingHero;
	Hero hero;

	bool isDragged;

	void Awake() {
		hero = GetComponent<Hero>();
		isDragged = false;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (!isDragged)
			return;
		if (other.gameObject.layer != LayerMask.NameToLayer("Hero"))
			return;

		mergingHero = other.GetComponent<Hero>();
	}

	void OnTriggerExit2D(Collider2D other) {
		if (!isDragged)
			return;
		if (other.gameObject.layer != LayerMask.NameToLayer("Hero"))
			return;

		if (other.gameObject == mergingHero?.gameObject) {
			mergingHero = null;
		}
	}

	void OnMouseDown() {
		isDragged = true;
	}

	void OnMouseDrag() {
		Vector3 mouseWorldPos = getMouseWorldPos();
		transform.position = new Vector3(mouseWorldPos.x, mouseWorldPos.y, 0);
	}

	void OnMouseUp() {
		isDragged = false;

		if (canMerge(hero, mergingHero)) {
			merge(hero, mergingHero);
		} else {
			transform.localPosition = Vector3.zero;
		}
	}

	Vector3 getMouseWorldPos() {
		float mousePosX = Mathf.Clamp(Input.mousePosition.x, 0, Screen.width);
		float mousePosY = Mathf.Clamp(Input.mousePosition.y, 0, Screen.height);

		return Camera.main.ScreenToWorldPoint(new Vector3(mousePosX, mousePosY, 0));
	}

	bool canMerge(Hero hero, Hero mergingHero) {
		bool sameType = mergingHero?.GetType() == hero.GetType();
		bool sameLevel = mergingHero?.getLevel() == hero.getLevel();
		return sameType && sameLevel;
	}

	void merge(Hero hero, Hero mergingHero) {
		// Target cell
		Cell cell = mergingHero.GetComponentInParent<Cell>();

		// Remove heroes from their respective cells
		hero.GetComponentInParent<Cell>().removeHero();
		mergingHero.GetComponentInParent<Cell>().removeHero();

		// Spawn a new hero at target cell
		HeroSpawner heroSpawner = LevelManager.getInstance().getHeroSpawner();
		heroSpawner.spawnRandomHeroAtCell(cell, hero.getLevel() + 1);
	}
}
