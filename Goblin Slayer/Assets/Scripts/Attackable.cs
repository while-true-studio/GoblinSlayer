﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
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
        Assert.IsNotNull(dead);
    }
    /// <summary>
    /// Called to deal damage to the gameObject
    /// </summary>
    /// <param name="damage">The amount of damage</param>
    public void OnAttack(float damage)
    {
        health.LoseHealth(damage);

        if (!health.Alive)
        {
            dead.OnDead();
        }

    }
}
