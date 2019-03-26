using UnityEngine;
using UnityEngine.Assertions;

public class AttackOnRange_AI : MonoBehaviour {
    public Transform target;
    public float attackDistance;

    private IAttacker_AI attacker_AI;

    private void Start()
    {
        attacker_AI = GetComponent<IAttacker_AI>();
        Assert.IsNotNull(attacker_AI, "ERROR: This GameObject does NOT contain any component of type Attacker_AI, and is REQUIRED!");
    }

    private void Update()
    {
        if (Vector2.Distance(target.position, transform.position) <= attackDistance)
            attacker_AI.Attack(target);
    }
}
