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
    private bool healingMode { get ; set; }
    public float healingTime = 1.0f;

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
            healingMode = false;
            StartCoroutine("HealingDoing");
        }
    }

    /// <summary>
    /// Heal health points
    /// </summary>
    public void Healing()
    {
        healingMode = true;
        healingAnim.SetBool("Healing", true);
        playerAnim.SetTrigger("Cast");
    }

    /// <summary>
    /// Timer for between heals
    /// </summary>
    /// <returns></returns>
    private IEnumerator HealingDoing()
    {
        yield return new WaitForSecondsRealtime(healingTime);
        hp.RestoreHP(heal);
    }

    /// <summary>
    /// Stop of heal and finish the healing animation
    /// </summary>
    public void EndHealing()
    {
        healingMode = false;
        healingAnim.SetBool("Healing", false);
    }

}
