using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinDead : MonoBehaviour, IDead
{
    private Animator animator;
    private float timeAnim = 1.0f;
    void IDead.OnDead()
    {
        Debug.Log("Imma Goblin and i'm ded. I'd like to keep raping but I need to go, bye");
        DyingAnimator();
        Destroy(gameObject,timeAnim);
    }

    private void Start()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
    }

    private void DyingAnimator()
    {
        animator.SetTrigger("Die");
    }
}
