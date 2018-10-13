using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : CharacterStats {

	public GameObject destroyedVersion;
	string clonedSuffix = "(Clone)";

	void Update() {
		if (currentHealth <= 0) {
			Shatter();
		}
	}

	public void Shatter() {
		Instantiate(destroyedVersion, transform.position, transform.rotation);
		Destroy(gameObject);
	}

	IEnumerator Wait() {

		yield return new WaitForSeconds(5);
		Debug.Log("GameObject.Find(destroyedVersion.name + clonedSuffix");
	}

}