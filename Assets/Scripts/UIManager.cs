using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(4)]
public class UIManager : MonoBehaviour {
	[Header("Stats Panel")]
	[SerializeField] Text cyclopsBeaten;
	[SerializeField] Text ghostsBeaten;
	[SerializeField] Text spidersBeaten;

	[Header("Button Panel")]
	[SerializeField] Button spawnButton;
	[SerializeField] Text score;

	[Header("Bottom Panel")]
	[SerializeField] Text manaReq;
	[SerializeField] Text mana;
	[SerializeField] Text wave;

	void Awake() {
		spawnButton.onClick.AddListener(LevelManager.getInstance().getHeroSpawner().spawnRandomHero);
	}

	void Start() {
		subscribeToEvents();
		updateMana();
		updateStats();
	}

	void subscribeToEvents() {
		Events.getInstance().waveBegan.AddListener(setWave);
		Events.getInstance().enemyBeaten.AddListener(delegate (EnemyType e) { updateMana(); });
		Events.getInstance().enemyBeaten.AddListener(delegate (EnemyType e) { updateStats(); });
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

	void updateStats() {
		StatManager statManager = LevelManager.getInstance().getStatManager();
		cyclopsBeaten.text = "x" + statManager.getCyclopsesBeaten().ToString();
		ghostsBeaten.text = "x" + statManager.getGhostsBeaten().ToString();
		spidersBeaten.text = "x" + statManager.getSpidersBeaten().ToString();

		score.text = "Score " + statManager.getScore();
	}
}
