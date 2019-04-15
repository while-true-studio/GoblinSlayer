using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour, IDead
{
    private Animator animator;
    private Rigidbody2D rb;
    private Collider2D coll;
    private float timeAnim = 2.0f;

    private void Start()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    void IDead.OnDead() 
    {
        DeadAnimator();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        coll.enabled = false;
    }

    private void DeadAnimator()
    {
        animator.SetBool("Die",true);
        StartCoroutine("TimeAnimation");
    }

    private IEnumerator TimeAnimation()
    {
        yield return new WaitForSecondsRealtime(timeAnim);
        GameManager.instancia.ResetScene(1);
    }
}
