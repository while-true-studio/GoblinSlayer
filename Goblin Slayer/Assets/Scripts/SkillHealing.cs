using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Mana))]
public class SkillHealing : MonoBehaviour
{
    public float healingPerSecond;
    public float manaPerHP;
    public float minMana;


    private Health health;
    private Mana mana;
    private Animator healingAnim;
    private Animator playerAnim;
    private AttackSounds attackSounds;

    private bool healing = false;

    private void Start()
    {
        health = GetComponent<Health>();
        mana = GetComponent<Mana>();
        healingAnim = transform.GetChild(1).GetComponent<Animator>();
        playerAnim = transform.GetChild(0).GetComponent<Animator>();
        attackSounds = GetComponentInChildren<AttackSounds>();
    }



    public void Heal()
    {
        float hp = healingPerSecond * Time.deltaTime;
        float manaCost = manaPerHP * hp;
        //If:
        // - We have the minimun mana required
        // - Need to Health
        if (mana.currentMana > minMana && health.currentHealth < health.maxHealth)
        {
            mana.UseMana(manaCost);
            health.RestoreHP(hp);
            if (!healing)
            {
                HealingEffects(true);
                healing = true;
            }
        }
    }

    public void StopHealing()
    {
        if (!healing) return;

        healing = false;
        HealingEffects(false);
    }

    /// <summary>
    /// Heal health points
    /// </summary>
    private void HealingEffects(bool active)
    {
        if (active)
            attackSounds.PlayEffect(attackSounds.healingEffect); 

        healingAnim.SetBool("Healing", active);
        playerAnim.SetBool("Healing", active);

    }
}