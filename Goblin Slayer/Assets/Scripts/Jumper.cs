using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Jumper : MonoBehaviour {

    public float jumpForce;

    private Rigidbody2D rb;
    private Animator animator;

    void Start ()
    {
        rb = GetComponent <Rigidbody2D> ();
        animator = transform.GetChild(0).GetComponent<Animator>();
    }
    /// <summary>
    /// Makes the gameObject jump.
    /// TODO: we're not checking if we're on ground, so can jump infintly
    /// </summary>
    public void Jump()
    {
        if(Mathf.Abs(rb.velocity.y) < Mathf.Epsilon)
        {
            rb.velocity += new Vector2(0, jumpForce);
            JumpAnimator();
        }
    }

    private void JumpAnimator()
    {
        animator.SetTrigger("Jump");
    }
}
