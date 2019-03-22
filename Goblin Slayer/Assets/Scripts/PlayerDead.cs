using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour, IDead
{
    private Animator animator;
    private float timeAnim = 2.0f;

    private void Start()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
    }

    void IDead.OnDead() 
    {
        DeadAnimator();
        Debug.Log("Imma player nad I'm Dead now :( *Ooof*");
    }

    private void DeadAnimator()
    {
        animator.SetTrigger("Die");
        StartCoroutine("TimeAnimation");
    }

    private IEnumerator TimeAnimation()
    {
        yield return new WaitForSecondsRealtime(timeAnim);
        GameManager.instancia.ResetScene(0);
    }
}
