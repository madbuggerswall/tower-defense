using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeController : MonoBehaviour {
	Hero mergingHero;
	Hero hero;

	void Awake() {
		hero = GetComponent<Hero>();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.layer == LayerMask.NameToLayer("Hero")) {
			mergingHero = other.GetComponent<Hero>();
		}
	}

	void OnMouseDown() {
	}

	void OnMouseDrag() {
		Vector3 mouseWorldPos = getMouseWorldPos();
		transform.position = new Vector3(mouseWorldPos.x, mouseWorldPos.y, 0);
	}

	void OnMouseUp() {
		bool sameType = mergingHero?.GetType() == hero.GetType();
		bool sameLevel = mergingHero?.getLevel() == hero.getLevel();
		if (sameType && sameLevel) {
			// Put a random level+1 hero in mergingHero's cell
			// Disable these two heroes
		} else {
			transform.localPosition = Vector3.zero;
		}
	}

	Vector3 getMouseWorldPos() {
		float mousePosX = Mathf.Clamp(Input.mousePosition.x, 0, Screen.width);
		float mousePosY = Mathf.Clamp(Input.mousePosition.y, 0, Screen.height);

		return Camera.main.ScreenToWorldPoint(new Vector3(mousePosX, mousePosY, 0));
	}
}
