using System;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Rigidbody2D))]
public class Walker : MonoBehaviour
{
    public enum Direction { LEFT = -1, RIGHT = 1 };

    public float velocity;

    private float initialVelocity;
    private Rigidbody2D rb;
    private Animator animator;
    private PlayerBaseSounds sounds;
    private Toes toes;
    //[SerializeField]uncomment for debug
    private bool canGoRight = true;
    //[SerializeField]
    private bool canGoLeft = true;

    private void Start()
    {
        initialVelocity = velocity;
        SetupDependencies();
    }

    protected void SetupDependencies()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        sounds = GetComponentInChildren<PlayerBaseSounds>();
        Assert.IsNotNull(animator, "ERROR: Couldn't find component of type 'Animator' in object \"" + gameObject.name + "\" or any of its children");
        toes = GetComponentInChildren<Toes>();
        Assert.IsNotNull(toes,
            "ERROR: Couldn't find component of type 'toes' in object \"" + gameObject.name + "\" or any of its children");
    }



    /// <summary>
    /// Makes the gameObject move in the given direction
    /// </summary>
    /// <param name="direction">The direction in which the gameObject should move</param>
    public virtual void Walk(Direction direction)
    {
        if (toes.OnGround || CanGoTo(direction))
        {
            var vel = rb.velocity;
            vel.x = (float)direction * velocity;
            rb.velocity = vel;
        }
        else Stop();

        if (!sounds.IsPlayingSound() && toes.OnGround)
            PlaySounds();


        CheckAnimator();
    }
    private void PlaySounds()
    {
        //Math.Abs(Mathf.Abs(rb.velocity.x) - initialVelocity) < float.Epsilon <=>
        //rb.velocity.x == initialVelocity, but prevent floating-point error
        if (Math.Abs(Mathf.Abs(rb.velocity.x) - initialVelocity) < float.Epsilon && Mathf.Abs(rb.velocity.x) > 0.25f)
        {
            sounds.PlayEffect(sounds.walk);
        }
        else if (Mathf.Abs(rb.velocity.x) > initialVelocity)
        {
            sounds.PlayEffect(sounds.run);
        }
    }

    public void Stop()
    {
        {
            var vel = rb.velocity;
            vel.x = 0;
            rb.velocity = vel;
        }
        sounds.StopSounds(true);
        animator.SetFloat("speedWalk", 0);
    }

    private void CheckAnimator()
    {
        animator.SetFloat("speedWalk", Mathf.Abs(rb.velocity.x));
    }

    bool CanGoTo(Direction direction)
    {
        return (direction == Direction.LEFT && canGoLeft) ||
               (direction == Direction.RIGHT && canGoRight);
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Blocks") ) return;

        ContactPoint2D[] contactPoints = new ContactPoint2D[collision.contactCount];
        collision.GetContacts(contactPoints);
        foreach (var contactPoint in contactPoints)
        {
            /**/ if (contactPoint.normal.x > 0)    canGoLeft = false;
            else if (contactPoint.normal.x < 0)   canGoRight = false;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        canGoRight = canGoLeft = true;
    }
}