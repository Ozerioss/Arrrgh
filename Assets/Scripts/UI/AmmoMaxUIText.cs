using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class AmmoMaxUIText : MonoBehaviour {

	public Weapon weapon;
	Text MaxAmmoValue;

	void Start() {
		MaxAmmoValue = GetComponent<Text>();
	}

	// Update is called once per frame
	void Update() {
		MaxAmmoValue.text = "/ " + weapon.maxAmmo.ToString();
	}
}