using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Shooter))]
public class Shooter_AI : MonoBehaviour, IAttacker_AI
{
    private SpriteRenderer spriteRenderer;
    private Shooter shooter;

    private void Start()
    {
        shooter = GetComponent<Shooter>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void Attack(Transform target)
    {
        shooter.Shoot(new Vector2(((transform.position - target.position).x < 0) ? 0.5f : -0.5f, 0.5f));
        FlipCast(target.position);
    }

    /// <summary>
    /// flip when attack in another direction
    /// </summary>
    /// <param name="direction"></param>
    private void FlipCast(Vector2 direction)
    {
        if (transform.position.x > direction.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
}
