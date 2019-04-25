
using UnityEngine;
[RequireComponent(typeof(MeleeAttacker))]
public class MeleeAttacker_AI : MonoBehaviour, IAttacker_AI
{
    private MeleeAttacker attacker;
    private EnemyLifeCircle enemyLifeCircle;//Only for Tracking
    void Start ()
    {
        attacker = GetComponent<MeleeAttacker>();
        enemyLifeCircle = GetComponent<EnemyLifeCircle>();
	}

    /// <summary>
    /// Attacks with a melee attack the <paramref name="target"/>
    /// </summary>
    /// <param name="target">The reciever of the attack</param>
    public void Attack(Transform target)
    {
        Vector2 dir = (target.position - transform.position).normalized;

        Tracker.Tracker.Instance.AddEvent(
            new Tracker.Events.EnemyAttack
            (
                enemyLifeCircle.id,
                Tracker.GetEnum.GetEnemyType(enemyLifeCircle),
                transform.position.x, transform.position.y,
                dir.x, dir.y, Tracker.Events.AttackType.MELEE
            )
        );

        attacker.MakeAttack(dir);
    }

	
}
