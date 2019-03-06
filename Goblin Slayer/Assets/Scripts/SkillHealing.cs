using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Health))]
public class SkillHealing : MonoBehaviour
{
    public int heal = 25;
    private Health hp;

    private void Start()
    {
        hp = GetComponent<Health>();
    }
    /// <summary>
    /// Heal health points
    /// </summary>
    public void Healing()
    {
        hp.RestoreHP(heal);
    }
}
