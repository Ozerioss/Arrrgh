using UnityEngine;
using UnityEngine.UI;

public class AmmoUIText : MonoBehaviour {

	public Weapon weapon;
	Text AmmoValue;

	void Start(){		
		AmmoValue = GetComponent<Text>();
	}

	// Update is called once per frame
	void Update () {
		AmmoValue.text = weapon.currentAmmo.ToString();
	}
}
