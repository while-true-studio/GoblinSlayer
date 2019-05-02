using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour, IDead
{
    private Animator animator;
    private Rigidbody2D rb;
    private Collider2D coll;
    public RageDoll rageDoll;
    private PlayerBaseSounds baseSounds;

    private void Start()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
        baseSounds = GetComponentInChildren<PlayerBaseSounds>();
    }

    void IDead.OnDead()
    {
        GetComponentInChildren<PlayerBaseSounds>().PlayEffect(baseSounds.playerDead);
        GameManager.instancia.GameOver();
        Instantiate(rageDoll, transform.position, transform.rotation);
        transform.GetChild(0).gameObject.SetActive(false);
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        GetComponent<Collider2D>().enabled = false;
    }
}

