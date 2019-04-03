using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Shooter))]
public class Shooter_AI : MonoBehaviour, IAttacker_AI
{
    private Shooter shooter;

    private void Start()
    {
        shooter = GetComponent<Shooter>();
    }

    public void Attack(Transform target)
    {
        shooter.Shoot(new Vector2(0.5f, ((transform.position - target.position).x > 0) ? 0.5f : -0.5f));
    }
}
