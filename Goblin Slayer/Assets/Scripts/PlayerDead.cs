using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour, IDead
{
    private Animator animator;
    private Rigidbody2D rb;
    private Collider2D coll;
    private float timeAnim = 2.0f;
    public RageDoll rageDoll;

    private void Start()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
    }

    void IDead.OnDead()
    {
        Instantiate(rageDoll, transform.position, transform.rotation);
        transform.GetChild(0).gameObject.SetActive(false);
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        GetComponent<Collider2D>().enabled = false;
        DamageScreen Go = GameObject.Find("HUD").GetComponent<DamageScreen>();
        Go.gameOver = true;
    }



}

