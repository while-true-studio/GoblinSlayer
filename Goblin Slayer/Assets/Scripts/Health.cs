using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public int maxHealth;
    public int currentHealth;
    public bool Invencible { get; set; }
    public void ToogleInvencible() { Invencible = !Invencible; }
    public bool Alive { get { return currentHealth > 0; } }
    private Animator animator;

    private void Start()
    {
        currentHealth = maxHealth;
        Invencible = false;
        animator = transform.GetChild(0).GetComponent<Animator>();
    }

    /// <summary>
    /// Applies damage and updates the gameObject's status (alive/dead)
    /// </summary>
    /// <param name="amount"> Amount of damage </param>
    public void LoseHealth(int amount)
    {
        if (Invencible) return;
        HitAnimator();
        currentHealth -= amount;
    }

    /// <summary>
    /// Recover HP and check if life is in the parameters
    /// </summary>
    /// <param name="amount"> Amount of HP recovered </param>
    public void RestoreHP(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
    }

    private void HitAnimator()
    {
        animator.SetTrigger("Hit");
    }
}
