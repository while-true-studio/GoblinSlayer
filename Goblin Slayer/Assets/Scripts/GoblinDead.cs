using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinDead : MonoBehaviour, IDead
{
    private Animator animator;
    private Rage playerRage;
    private Rigidbody2D rb;
    private Collider2D collider2D;
    public int rageAmount = 2;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        playerRage = GameObject.Find("Player").GetComponent<Rage>();
        rb = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
    }

    void IDead.OnDead()
    {
        GetComponent<GoblinState>().GoblinIsDead();
        GameManager.instancia.AddEnemy();
        DyingAnimator();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        collider2D.enabled = false;
        playerRage.AddRage(rageAmount);
        Destroy(gameObject,1f);
    }
    
    private void DyingAnimator()
    {
        animator.SetTrigger("Die");
    }
}
