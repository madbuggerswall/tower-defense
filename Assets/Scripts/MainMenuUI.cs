using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour {
	[SerializeField] Button playButton;

	void Awake() {
		playButton.onClick.AddListener(play);
	}

	// Scene management
	public void play() {
		SceneManager.LoadScene(1);
	}
}
