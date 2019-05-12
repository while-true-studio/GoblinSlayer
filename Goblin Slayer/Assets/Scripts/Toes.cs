using UnityEngine;

public class Toes : MonoBehaviour
{
    public bool OnGround { get; private set; }
    private Animator fallingAnimator;

    private void Start()
    {
        fallingAnimator = transform.parent.GetComponentInChildren<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //TODO: Use collisionMask instead of tags
        if (collision.tag == "Blocks")
            OnGround = true;
        AnimatorFalling();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //TODO: Use collisionMask instead of tags
        if (collision.tag == "Blocks")
            OnGround = false;
        AnimatorFalling();
    }

    private void AnimatorFalling()
    {
        fallingAnimator.SetBool("OnGround",OnGround);
    }
}
