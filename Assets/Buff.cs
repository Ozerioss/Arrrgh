using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour {

    public GameObject pickupEffect;

    public float multiplier = 1.1f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Pickup(other);
        }


    }

    void Update()
    {
        transform.Rotate(new Vector3(35, 0, 45) * Time.deltaTime);
    }

    void Pickup(Collider player)
    {
        Debug.Log("Buff picked up");
        Instantiate(pickupEffect, transform.position, transform.rotation);

        player.transform.localScale *= multiplier; // Effect on player

        Destroy(gameObject);
    }
}
