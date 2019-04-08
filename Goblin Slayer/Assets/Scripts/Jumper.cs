using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Jumper : MonoBehaviour
{
    public float jumpForce;
    private Rigidbody2D rb;
    public Toes toes {  get; private set; }
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        toes = GetComponentInChildren<Toes>();
        animator = transform.GetChild(0).GetComponent<Animator>();
    }

    public void Jump()
    {
        if (toes.onGound)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            JumpAnimator();
        }
            
    }


    private void JumpAnimator()
    {
        animator.SetTrigger("Jump");
    }

}