using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Jumper : MonoBehaviour {

    public float jumpForce;

    private Rigidbody2D rb;

	void Start ()
    {
        rb = GetComponent <Rigidbody2D> ();
	}

    /// <summary>
    /// Makes the gameObject jump.
    /// </summary>
    public void Jump()
    {
        if(Mathf.Abs(rb.velocity.y) < Mathf.Epsilon)
            rb.velocity += new Vector2(0, jumpForce);
    }
}
