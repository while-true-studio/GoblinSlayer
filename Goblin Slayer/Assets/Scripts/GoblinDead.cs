using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinDead : MonoBehaviour, IDead
{
    private Animator animator;
    private Rage playerRage;
    private float timeAnim = 0.4f;
    public int rageAmount = 2;

    void IDead.OnDead()
    {
        DyingAnimator();
        playerRage.AddRage(rageAmount);
        Destroy(gameObject,timeAnim);
    }

    private void Start()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
        playerRage = GameObject.Find("Player").GetComponent<Rage>();
    }

    private void DyingAnimator()
    {
        animator.SetTrigger("Die");
    }
}
