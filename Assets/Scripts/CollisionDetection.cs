using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour {

    public PlayerMovement playerMovement;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("Obstacle"))
        {
            Debug.Log("Obstacle");
            Destroy(collision.gameObject);
            //FindObjectOfType<GameManager>().GameOver();
            //movement.horizontalForce = 1000;
        }
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
}
