using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Mana))]
public class SkillHealing : MonoBehaviour
{
   
    public float manaCost = 0.0f;
    private Health hp;
    private Mana mn;
    private Animator healingAnim;
    private Animator playerAnim;
    private AttackSounds attackSounds;
    public bool healingMode;
    public float healingTime;
    public float timerHeal = 0.0f;

    private void Start()
    {
        hp = GetComponent<Health>();
        mn = GetComponent<Mana>();
        healingAnim = transform.GetChild(1).GetComponent<Animator>();
        playerAnim = transform.GetChild(0).GetComponent<Animator>();
        attackSounds = GetComponentInChildren<AttackSounds>();
    }

    /*void Update()
    {

        if (healingMode)
        {
         
            timerHeal = Time.deltaTime * healingTime;
            if (hp.currentHealth < hp.maxHealth && mn.UseMana(manaCost) && mn.currentMana > manaCost * 30)
            {
                hp.RestoreHP((int)timerHeal);
            }

        }
        else
        {
            timerHeal = 0.0f;
        }
    }*/

    public void Heal()
    {
        timerHeal = healingTime * Time.deltaTime;
        if (mn.currentMana > manaCost * 2 && hp.currentHealth < hp.maxHealth   && mn.UseMana(manaCost) )
        {
           
            mn.currentMana = mn.currentMana-manaCost;
            hp.RestoreHP((int)timerHeal);
        }

    }
    /// <summary>
    /// Heal health points
    /// </summary>
    public void Healing(bool status)
    {
        if (hp.currentHealth == hp.maxHealth || mn.currentMana < manaCost *2) { status = false; }
        if (status) { attackSounds.PlayEffect(attackSounds.healingEffect); }

        healingMode = status;
        healingAnim.SetBool("Healing", status);
        playerAnim.SetBool("Healing", status);

    }
}