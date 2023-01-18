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
		Events.getInstance().waveBegan.AddListener(setWave);
	}

	void setWave(int wave) {
		this.wave.text = "Wave\n" + wave.ToString();
	}
}
