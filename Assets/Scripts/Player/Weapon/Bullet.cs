using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float bulletSpeed = 1500f;
	public int damage = 1;
	public Rigidbody rb;

	public GameObject impactEffect;

	// Use this for initialization
	void Start() {
		//We use the up direction because the bullet is rotated, therefore the Z Axis is on the vertical
		rb.velocity = transform.up * bulletSpeed * Time.deltaTime;
	}

	/// <summary>
	/// OnTriggerEnter is called when the Collider other enters the trigger.
	/// </summary>
	/// <param name="other">The other Collider involved in this collision.</param>
	void OnTriggerEnter(Collider other) {
		CharacterStats enemy = other.GetComponent<CharacterStats>();
		if (enemy != null) {
			enemy.TakeDamage(damage);
		}

		Vector3 impactPosition = new Vector3(other.transform.position.x, other.transform.position.y + 1.5f, other.transform.position.z);
		Instantiate(impactEffect, impactPosition, other.transform.rotation);

		Destroy(gameObject);
	}

}