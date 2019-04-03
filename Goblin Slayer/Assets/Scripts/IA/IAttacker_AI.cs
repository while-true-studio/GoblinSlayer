using UnityEngine;

interface IAttacker_AI
{
    /// <summary>
    /// Attacks the given target.
    /// Note: The way that attack if portraid must be implemented be the child component
    /// </summary>
    /// <param name="target">The reciver of the attack</param>
    void Attack(Transform target);
}