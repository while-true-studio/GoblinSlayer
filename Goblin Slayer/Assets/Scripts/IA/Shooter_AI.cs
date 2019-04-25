using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Shooter))]
public class Shooter_AI : MonoBehaviour, IAttacker_AI
{
    private SpriteRenderer spriteRenderer;
    private Shooter shooter;
    private EnemyLifeCircle enemyLifeCircle;//Only for tracking

    private void Start()
    {
        shooter = GetComponent<Shooter>();
        enemyLifeCircle = GetComponent<EnemyLifeCircle>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void Attack(Transform target)
    {
        Vector2 dir = new Vector2(((transform.position - target.position).x < 0) ? 0.5f : -0.5f, 0.5f);

        Tracker.Tracker.Instance.AddEvent(
            new Tracker.Events.EnemyAttack
            (
                enemyLifeCircle.id,
                Tracker.GetEnum.GetEnemyType(enemyLifeCircle),
                transform.position.x, transform.position.y,
                dir.x, dir.y, Tracker.Events.AttackType.DISTANCE
            )
        );

        shooter.Shoot(dir);
        //Flip if neccesary
        //FIX-ME: this component shoudn't do this
        spriteRenderer.flipX = transform.position.x > dir.x;
    }
}
