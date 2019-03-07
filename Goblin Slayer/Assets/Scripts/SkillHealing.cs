using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Health))]
public class SkillHealing : MonoBehaviour
{
    public int heal = 25;
    private Health hp;
    private Animator healingAnim;
    private bool healingMode { get ; set; }
    public float healingTime = 5.0f;

    private void Start()
    {
        hp = GetComponent<Health>();
        healingAnim =transform.GetChild(1).GetComponent<Animator>();
    }
    /// <summary>
    /// Heal health points
    /// </summary>
    public void Healing()
    {
        healingMode = true;
        hp.RestoreHP(heal);
        healingAnim.SetBool("Healing", true);
        StartCoroutine("HealingDoing");
    }

    private IEnumerator HealingDoing()
    {
        yield return new WaitForSecondsRealtime(healingTime);
        healingMode = false;
        healingAnim.SetBool("Healing", false);
    }

}
