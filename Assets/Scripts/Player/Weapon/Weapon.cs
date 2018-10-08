using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public Transform firePoint;
	public GameObject bulletPrefab;
	public int currentAmmo = 20;
	public int maxAmmo = 20;

	// Update is called once per frame
	void Update() {
		//Fire1 == Space button on computer
		if (Input.GetButtonDown("Fire1")) {
			if (currentAmmo > 0 && currentAmmo <= maxAmmo)
				Shoot();
			else
				Debug.Log("Show UI no ammo");
		}
	}

	void Shoot() {
		//We use the bullet prefab rotation, otherwise the bullet is vertical
		Instantiate(bulletPrefab, firePoint.position, bulletPrefab.transform.rotation);
		currentAmmo--;		
	}
}