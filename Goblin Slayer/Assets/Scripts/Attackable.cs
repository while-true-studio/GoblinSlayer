using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(IDead))]
public class Attackable : MonoBehaviour
{
    private Health health;
    private IDead dead;

    private void Start()
    {
        health = GetComponent<Health>();
        dead = GetComponent<IDead>();
    }
    /// <summary>
    /// Called to deal damage to the gameObject
    /// </summary>
    /// <param name="damage">The amount of damage</param>
    public void OnAttack(int damage)
    {
        health.LoseHealth(damage);


        if (!health.Alive)
        {
            dead.OnDead();
        }

    }
}
