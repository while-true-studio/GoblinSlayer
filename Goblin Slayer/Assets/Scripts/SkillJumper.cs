using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillJumper :  Jumper
{
    public int manaCost;
    private Mana mana;
    private Animator fallingAnimator;
    private Toes toes;
    private Rigidbody2D rb;

	void Start ()
    {
        mana = GetComponent<Mana>();
        fallingAnimator = transform.GetChild(0).GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        toes = GetComponentInChildren<Toes>();
    }
	

    public void MakeADoubleJump(Vector2 dir)
    {
        if ( mana.UseMana(manaCost) && !toes.onGound)
        {
            rb.AddForce(dir * jumpForce * 2, ForceMode2D.Impulse);
            AnimatorFalling();
        }
    }

    private void AnimatorFalling()
    {
        fallingAnimator.SetFloat("Falling",rb.velocity.y);
    }

}
