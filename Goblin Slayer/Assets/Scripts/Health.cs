using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public int maxHealth;
    public float currentHealth;
    public bool Alive { get; private set; }
    private Animator animator;

    private void Start()
    {
        currentHealth = maxHealth;
        animator = transform.GetChild(0).GetComponent<Animator>();
    }

    /// <summary>
    /// Applies damage and updates the gameObject's status (alive/dead)
    /// </summary>
    /// <param name="amount"> Amount of damage </param>
    public void LoseHealth(float amount)
    {
        HitAnimator();
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
    public float GetHP()
    {
        return currentHealth;
    }

    private void HitAnimator()
    {
        animator.SetTrigger("Hit");
    }
}
