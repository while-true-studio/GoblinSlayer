using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Health))]
public class HealingSkill : MonoBehaviour
{
    public int heal;
    private Health hp;

    private void Start()
    {
        hp = GetComponent<Health>();
    }
    /// <summary>
    /// Heal health points
    /// </summary>
    /// <param name="heal">How much you want to heal</param>
    public void Healing(int heal)
    {
        hp.Heal(heal);
    }
}
