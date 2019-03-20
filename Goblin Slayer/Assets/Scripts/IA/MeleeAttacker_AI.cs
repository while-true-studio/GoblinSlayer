
using UnityEngine;
[RequireComponent(typeof(MeleeAttacker))]
public class MeleeAttacker_AI : MonoBehaviour, IAttacker_AI
{
    private MeleeAttacker attacker;
    void Start () {
        attacker = GetComponent<MeleeAttacker>();
	}
    public void Attack(Transform target)
    {
        attacker.MakeAttack((target.position - transform.position).normalized);
    }

	
}
