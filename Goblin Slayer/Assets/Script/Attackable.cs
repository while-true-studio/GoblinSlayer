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
    public void OnAttack(int damage)
    {
        health.ReciveDamage(damage);
        if (!health.isAlive)
            dead.OnDead();
            
    }


}
