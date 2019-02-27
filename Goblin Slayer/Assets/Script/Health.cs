using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health: MonoBehaviour
{
    public float health { get; private set; }
    public float maxHealth { get; private set; }
    public bool isAlive { get; private set; }
    private void Start()
    {
        isAlive = true;
    }
    public void ReciveDamage(float damage)
    {
        health -= damage;
        if (health < 0)
        {
            health = 0;
            isAlive = false;
        }
    }

    public void Heal(float amount)
    {
        health += amount;
        if (health > maxHealth) health = maxHealth;
    }

}
