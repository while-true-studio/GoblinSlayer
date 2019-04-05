using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Jumper : MonoBehaviour
{
    public int manaCost = 20;
    private Mana mana;
    public float jumpForce;
    private Rigidbody2D rb;
    public bool onGround;
    public Collider2D toes;
    private Animator animator;

    void Start()
    {
        mana = GetComponent<Mana>();
        rb = GetComponent<Rigidbody2D>();
        onGround = true;
        animator = transform.GetChild(0).GetComponent<Animator>();

    }
    public void SkillJump(Vector2 dir)
    {
        if (onGround) { Jump(); }
        else
        {
            if (mana.UseMana(manaCost))
                rb.AddForce(dir * jumpForce * 2, ForceMode2D.Impulse);
        }
    }
    public void Jump()
    {
        if (onGround)
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        onGround = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        onGround = false;
    }
    private void JumpAnimator()
    {
        animator.SetTrigger("Jump");
    }
}