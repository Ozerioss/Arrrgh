using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats {

    public GameManager gameManager;
    public override void Die()
    {
        base.Die();
        // Debug.Log("Player death");
        gameManager.GameOver();
        Destroy(gameObject);
        //Death stuff
    }
}
