using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Carry some singletons over here, LevelManager can be a singleton mediator
public class LevelManager : MonoBehaviour {
	StatManager statManager;

	void Awake() {
		// Gamemanager
		Application.targetFrameRate = 60;

		statManager = new StatManager();
	}
}
