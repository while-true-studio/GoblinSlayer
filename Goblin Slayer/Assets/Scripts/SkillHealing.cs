using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Health))]
public class SkillHealing : MonoBehaviour
{
    public int heal = 1;
    private Health hp;
    private Animator healingAnim;
    private Animator playerAnim;
    public bool healingMode;
    public float healingTime;
    public float timerHeal = 0.0f;

    private void Start()
    {
        hp = GetComponent<Health>();
        healingAnim =transform.GetChild(1).GetComponent<Animator>();
        playerAnim = transform.GetChild(0).GetComponent<Animator>();
    }

    private void Update()
    {

        if(healingMode)
        {
            timerHeal = Time.deltaTime * healingTime;
            hp.RestoreHP((int)timerHeal);
        }
        else
        {
            timerHeal = 0.0f;
        }
    }

    /// <summary>
    /// Heal health points
    /// </summary>
    public void Healing(bool status)
    {
        healingMode = status;
        healingAnim.SetBool("Healing", status);
        playerAnim.SetBool("Healing",status);
    }

    /// <summary>
    /// Timer for between heals
    /// </summary>
    /// <returns></returns>
    private IEnumerator HealingDoing()
    {
        yield return new WaitForSecondsRealtime(healingTime);
        hp.RestoreHP(heal);
        print("HEALING!");
    }



}
