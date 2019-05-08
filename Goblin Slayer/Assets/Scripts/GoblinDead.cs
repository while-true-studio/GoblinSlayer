using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinDead : MonoBehaviour, IDead
{
    //private Animator animator;
    private Rage playerRage;
    public int rageAmount = 2;
    public RageDoll rageDoll;
    private PlayerBaseSounds sounds;
    private bool goblinDead = false;

    private void Start()
    {
        sounds = GetComponentInChildren<PlayerBaseSounds>();
        //animator = GetComponentInChildren<Animator>();
        playerRage = GameObject.Find("Player").GetComponent<Rage>();
    }

    public void OnDead()
    {
        goblinDead = true;
        //Debug.Log("Goblin dead");
    }

    public void ForcefullKill()
    {
        goblinDead = true;
        sounds.PlayEffect(sounds.dead);
        GetComponent<GoblinState>().GoblinIsDead();
        GameManager.instancia.AddEnemy();
        playerRage.AddRage(rageAmount);
        Instantiate(rageDoll, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (goblinDead && collision.GetContact(0).normal == Vector2.up)
        {
            //Debug.Log("The destroy function");
            sounds.PlayEffect(sounds.dead);
            GetComponent<GoblinState>().GoblinIsDead();
            GameManager.instancia.AddEnemy();
            playerRage.AddRage(rageAmount);
            Instantiate(rageDoll, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
