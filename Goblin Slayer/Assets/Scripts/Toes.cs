using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toes : MonoBehaviour
{
    public bool onGound { get; private set; }
    private Animator fallingAnimator;

    private void Start(){fallingAnimator = transform.parent.GetChild(0).GetComponent<Animator>();}


    private void OnTriggerEnter2D(Collider2D collision){if (collision.tag == "Blocks") { onGound = true; } AnimatorFalling(); }

    private void OnTriggerExit2D(Collider2D collision) { if (collision.tag == "Blocks") { onGound = false; } AnimatorFalling(); }

    private void AnimatorFalling()
    {
        fallingAnimator.SetBool("OnGround",onGound);
    }

}
