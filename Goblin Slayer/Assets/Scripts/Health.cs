using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public int maxHealth;
    public int currentHealth;
    public bool Alive { get; private set; }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    /// <summary>
    /// Applies damage and updates the gameObject's status (alive/dead)
    /// </summary>
    /// <param name="amount"> Amount of damage </param>
    public void LoseHealth(int amount)
    {
        currentHealth -= amount;
        Alive = !Dead();
    }

    /// <summary>
    /// Check if the gameObject's is alive or dead
    /// </summary>
    /// <returns></returns>
    private bool Dead()
    {
        return currentHealth <= 0;
    }


    /// <summary>
    /// Recover HP and check if life is in the parameters
    /// </summary>
    /// <param name="amount"> Amount of HP recovered </param>
    public void RestoreHP(int amount)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += amount;
        }
        EqualHP();
        print(currentHealth);
    }

    /// <summary>
    /// Equal life to the fullest if it go beyond the limits
    /// </summary>
    private void EqualHP()
    {
        if (currentHealth > maxHealth) currentHealth = maxHealth;
    }

    /// <summary>
    /// Get current HP
    /// </summary>
    /// <returns></returns>
    public int GetHP()
    {
        return currentHealth;
    }
}
