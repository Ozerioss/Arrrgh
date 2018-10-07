using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour {

    public PlayerMovement playerMovement;
    Health health;
    public PlayerStats stats;

    void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag.Equals("Obstacle")) {
            Debug.Log("Obstacle");
            health.currentHealth--;
            Destroy(collision.gameObject);
            stats.TakeDamage(40);
            //FindObjectOfType<GameManager>().GameOver();
            //movement.horizontalForce = 1000;
        }
    }

    // Use this for initialization
    void Start() {
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update() {

    }

}