using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {

    public Stat maxHealth;
    public int maxShield = 100;
    public int currentHealth { get; private set; } // get from all classes but set only from here
    public int currentShield { get; private set; }

    public Stat damage;
    public Stat armor;


    private void Awake()
    {
        currentHealth = maxHealth.GetValue();
        currentShield = maxShield;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        // To do add shield logic + modifier logic
        /*damage -= armor.GetValue();

        damage = Mathf.Clamp(damage, 0, int.MaxValue); // so that damage is never negative*/

        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int heal)
    {
        currentHealth += heal;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth.GetValue());
    }


    public virtual void Die()
    {
        Debug.Log("U ded");
    }
}
