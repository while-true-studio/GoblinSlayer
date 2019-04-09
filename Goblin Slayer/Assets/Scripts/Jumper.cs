using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Jumper : MonoBehaviour
{
    public float jumpForce;
    public Rigidbody2D rb {  get; set; }
    public Toes toes { get; set; }
    private Animator animator;

    void Awake()
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