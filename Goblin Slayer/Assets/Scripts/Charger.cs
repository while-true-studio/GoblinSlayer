using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Walker))]
[RequireComponent(typeof(Rigidbody2D))]
public class Charger : MonoBehaviour
{
    public Transform PlayerTransform;
    public float Range = 15;
    public float Speed = 5;

    private Walker walker;
    // private Animator animator;
    private Rigidbody2D enemyRB;

    // Facing
    private bool canFlip = true;
    private bool facingRight;

    // Attacking
    public float chargeTime;
    private float startChargeTime;
    private bool charging;

    private void Start()
    {
        // animator = GetComponent<Animator>();
        enemyRB = GetComponent<Rigidbody2D>();
        walker = GetComponent<Walker>();
        facingRight = true;
    }

    // Update is called once per frame
    private void Update()
    {
        float playerX = PlayerTransform.position.x;
        float startX = transform.position.x;

        bool inRange = facingRight ? startX - playerX < Range : playerX - startX < Range;

        if (inRange)
        {
            if (!charging)
                PlayerOnRangeEnter();
            else
                PlayerOnRangeStay();
        }
        else if (charging)
        {
            PlayerOnRangeExit();
        }
        else
        {
            PlayerRangeFlip();
        }
    }

    private void PlayerRangeFlip()
    {
        if (facingRight && PlayerTransform.position.x < transform.position.x)
            FlipFacing();
        else if (!facingRight && PlayerTransform.position.x > transform.position.x)
            FlipFacing();
    }

    private void PlayerOnRangeEnter()
    {
        Debug.Log("PlayerOnRangeEnter");
        if (facingRight && PlayerTransform.position.x < transform.position.x)
            FlipFacing();
        else if (!facingRight && PlayerTransform.position.x > transform.position.x)
            FlipFacing();

        canFlip = false;
        charging = true;
        startChargeTime = Time.time + chargeTime;
        walker.enabled = false;
        enemyRB.velocity = new Vector2(0f, 0f);
    }

    private void PlayerOnRangeStay()
    {
        Debug.Log("PlayerOnRangeStay");
        if (startChargeTime < Time.time)
        {
            enemyRB.AddForce(new Vector2(facingRight ? Speed : -Speed, 0f), ForceMode2D.Force);
            // animator.SetBool("isCharging", true);
        }
    }

    private void PlayerOnRangeExit()
    {
        Debug.Log("PlayerOnRangeExit");
        canFlip = true;
        charging = false;
        enemyRB.velocity = new Vector2(0f, 0f);
        // animator.SetBool("isCharging", false);
        walker.enabled = true;
    }

    private void FlipFacing()
    {
        Debug.Log("FlipFacing");
        if (!canFlip) return;
        transform.localScale.Set(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        facingRight = !facingRight;
    }
}
