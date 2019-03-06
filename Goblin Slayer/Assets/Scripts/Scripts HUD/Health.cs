using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public float maxHealth;
    public float currentHealth;
    public bool Alive { get; private set; }
    
    /// <summary>
    /// Applies damage and updates the gameObject's status (alive/dead)
    /// </summary>
    /// <param name="amount"> Amount of damage </param>
    public void LoseHealth(float amount)
    {
        currentHealth -= amount;
        EqualHP();
        Alive = !Dead();
    }

    /// <summary>
    /// Check if the gameObject's is alive or dead
    /// </summary>
    /// <returns></returns>
    public bool Dead()
    {
        return currentHealth <= 0;
    }


    /// <summary>
    /// Recover HP and check if life is in the parameters
    /// </summary>
    /// <param name="amount"> Cantidad de vida que recupera </param>
    public void RestoreHP(float amount)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += amount;
        }
        EqualHP();
    }

    /// <summary>
    /// Keep life between the bounds.
    /// </summary>
    public void EqualHP()
    {
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        else if (currentHealth < 0) currentHealth = 0;
    }

    /// <summary>
    /// Get current HP
    /// </summary>
    /// <returns></returns>
    public float GetHP()
    {
        return currentHealth;
    }
}
