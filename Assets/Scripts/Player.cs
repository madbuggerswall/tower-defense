using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	const int manaIncrement = 10;

	[SerializeField] int mana;
	[SerializeField] int manaRequired;

	void Awake() {

	}
}
