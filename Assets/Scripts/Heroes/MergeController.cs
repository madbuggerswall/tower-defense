using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeController : MonoBehaviour {
	[SerializeField] Hero mergingHero;
	Hero hero;

	// This guard avoids undesired merges
	bool dragged;

	void Awake() {
		hero = GetComponent<Hero>();
		dragged = false;
	}

	// Detect merging candidate
	void OnTriggerEnter2D(Collider2D other) {
		if (!dragged)
			return;
		if (other.gameObject.layer != LayerMask.NameToLayer("Hero"))
			return;

		mergingHero = other.GetComponent<Hero>();
	}

	// Avoid undesired/cancelled merges
	void OnTriggerExit2D(Collider2D other) {
		if (!dragged)
			return;
		if (other.gameObject.layer != LayerMask.NameToLayer("Hero"))
			return;

		if (other.gameObject == mergingHero?.gameObject) {
			mergingHero = null;
		}
	}

	// Mark hero to avoid undesired merges
	void OnMouseDown() {
		dragged = true;
	}

	// Drag the hero
	void OnMouseDrag() {
		Vector3 mouseWorldPos = getMouseWorldPos();
		transform.position = new Vector3(mouseWorldPos.x, mouseWorldPos.y, 0);
	}

	// Merge heroes if they are mergeable
	void OnMouseUp() {
		dragged = false;

		if (canMerge(hero, mergingHero)) {
			merge(hero, mergingHero);
		} else {
			transform.localPosition = Vector3.zero;
		}
	}

	// This should be in an InputManager class
	Vector3 getMouseWorldPos() {
		float mousePosX = Mathf.Clamp(Input.mousePosition.x, 0, Screen.width);
		float mousePosY = Mathf.Clamp(Input.mousePosition.y, 0, Screen.height);

		return Camera.main.ScreenToWorldPoint(new Vector3(mousePosX, mousePosY, 0));
	}

	// If heroes are the same type and same level they can merge
	bool canMerge(Hero hero, Hero mergingHero) {
		bool sameType = mergingHero?.GetType() == hero.GetType();
		bool sameLevel = mergingHero?.getLevel() == hero.getLevel();
		return sameType && sameLevel;
	}

	// Spawn a random promoted hero
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

	// Getters
	public bool isDragged(){return dragged;}
}
