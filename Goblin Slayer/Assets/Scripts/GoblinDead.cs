using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tracker;

public class GoblinDead : MonoBehaviour, IDead
{
    public int rageAmount = 2;
    public RageDoll rageDoll;

    private Animator animator;
    private Rage playerRage;
    //private Rigidbody2D rb;??

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        playerRage = GameObject.Find("Player").GetComponent<Rage>();
    }

    void IDead.OnDead()
    {
        GetComponent<GoblinState>().GoblinIsDead();
        GameManager.instancia.AddEnemy();
        playerRage.AddRage(rageAmount);
        Instantiate(rageDoll,transform.position,transform.rotation);
        Destroy(gameObject);
    }
    
}
