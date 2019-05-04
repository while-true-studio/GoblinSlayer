using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillJumper :  Jumper
{
    public int manaCost;
    private Mana mana;
    private Animator fallingAnimator;
    private Animator doubleJump;
    private AttackSounds sounds;

	void Start ()
    {
        mana = GetComponent<Mana>();
        fallingAnimator = transform.GetChild(0).GetComponent<Animator>();
        doubleJump = transform.GetChild(1).GetComponent<Animator>();
        sounds = GetComponentInChildren<AttackSounds>();
    }
	

    public void MakeADoubleJump(Vector2 dir)
    {
        if ( mana.UseMana(manaCost) && !toes.IsOverGround())
        {
            DoubleJumpAnimation();
            rb.velocity = Vector2.zero;
            rb.AddForce(dir * jumpForce * 2, ForceMode2D.Impulse);
            AnimatorFalling();
        }
    }

    private void AnimatorFalling()
    {
        fallingAnimator.SetFloat("Falling",rb.velocity.y);
    }

    private void DoubleJumpAnimation()
    {
        doubleJump.SetTrigger("Double");
        sounds.PlayEffect(sounds.doubleJump);
    }


}
