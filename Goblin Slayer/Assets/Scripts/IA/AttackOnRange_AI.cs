using UnityEngine;
using UnityEngine.Assertions;

public class AttackOnRange_AI : MonoBehaviour {
    private IAttacker_AI attacker_AI;
    public Transform target;

    private void Start()
    {
        attacker_AI = GetComponent<IAttacker_AI>();
        Assert.IsNotNull(attacker_AI, "ERROR: This GameObject does NOT contain any component of type Attacker_AI, and is REQUIRED!");
    }
    
    public void Attack()
    {
        attacker_AI.Attack(target);
    }
}
