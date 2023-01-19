using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(4)]
public class UIManager : MonoBehaviour {
	[SerializeField] Button spawnButton;
	[SerializeField] Text manaReq;
	[SerializeField] Text mana;
	[SerializeField] Text wave;

	void Awake() {
		spawnButton.onClick.AddListener(LevelManager.getInstance().getHeroSpawner().spawnRandomHero);
	}

	void Start() {
		subscribeToEvents();
		updateMana();
	}

	void subscribeToEvents() {
		Events.getInstance().waveBegan.AddListener(setWave);
		Events.getInstance().enemyBeaten.AddListener(delegate (EnemyType e) { updateMana(); });
		Events.getInstance().heroSpawned.AddListener(delegate (HeroType h) { updateMana(); });
	}

	void setWave(int wave) {
		this.wave.text = "Wave\n" + wave.ToString();
	}

	void updateMana() {
		HeroSpawner heroSpawner = LevelManager.getInstance().getHeroSpawner();

		spawnButton.interactable = (heroSpawner.getMana() >= heroSpawner.getManaRequired());
		manaReq.text = "Mana Req\n" + heroSpawner.getManaRequired().ToString();
		mana.text = "Mana\n" + heroSpawner.getMana().ToString();
	}
}
