using System;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Rigidbody2D))]
public class Walker : MonoBehaviour
{

    public float velocity;
    public WalkingState walkingState { get; private set; }

    private float velocityStart;
    private Rigidbody2D rb;
    private Animator animator;
    private PlayerBaseSounds sounds;
    private Toes toes;
    [SerializeField]
    private bool canGoRight = true;
    [SerializeField]
    private bool canGoLeft = true;

    private void Start()
    {
        velocityStart = velocity;
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

    public enum WalkingState { STOP = 0, RIGHT = 1, LEFT = -1 };
    public enum WalkDirection { RIGHT = WalkingState.RIGHT, LEFT = WalkingState.LEFT };


    /// <summary>
    /// Makes the gameObject move in the given direction
    /// </summary>
    /// <param name="direction">The direction in which the gameObject should move</param>
    public virtual void Walk(WalkDirection direction)
    {
        walkingState = (WalkingState)direction;

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
        //Math.Abs(Mathf.Abs(rb.velocity.x) - velocityStart) < float.Epsilon <=>
        //rb.velocity.x == velocityStart, but prevent floating-point error
        if (Math.Abs(Mathf.Abs(rb.velocity.x) - velocityStart) < float.Epsilon && Mathf.Abs(rb.velocity.x) > 0.25f)
        {
            sounds.PlayEffect(sounds.walk);
        }
        else if (Mathf.Abs(rb.velocity.x) > velocityStart)
        {
            sounds.PlayEffect(sounds.run);
        }
    }

    public void Stop()
    {
        walkingState = WalkingState.STOP;
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

    bool CanGoTo(WalkDirection direction)
    {
        return (direction == WalkDirection.LEFT && canGoLeft) ||
               (direction == WalkDirection.RIGHT && canGoRight);
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag != "Blocks" ) return;

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