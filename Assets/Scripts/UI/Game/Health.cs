using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	public int currentHealth;
	public int maxHealth;

	public GameObject HeartContainer;
	public Image[] hearths;
	public Sprite emptyHearth;
	public Sprite fullHearth;
	public Image healthPrefab;

	void Start() {
				
	}

	void Update() {
		for (int i = 0; i < hearths.Length; i++) {
			if (i < currentHealth) {
				hearths[i].sprite = fullHearth;
			} else {
				hearths[i].sprite = emptyHearth;
			}

			if (i < maxHealth) {
				hearths[i].enabled = true;
			} else {
				hearths[i].enabled = false;
			}
		}
	}

}