using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    Health health;
    float dmg, restoreHP;
    Scrollbar healthBar;

    void Start()
    {
        health = GetComponent<Health>();
        healthBar = GetComponent<Scrollbar>();
        health.maxHealth = healthBar.size ;
        health.currentHealth = health.maxHealth;
        dmg = healthBar.size * 0.1f; //this variable is for testing
        restoreHP = healthBar.size * 0.05f * Time.deltaTime;
    }

    void Update()
    {
        healthBar.size = health.currentHealth;
        if (!health.Dead()) health.RestoreHP(restoreHP);       
    }

    /// <summary>
    /// The method to deal damage to the health bar.
    /// </summary>
    public void DealDMG()
    {
        health.LoseHealth(dmg);
    }
}
