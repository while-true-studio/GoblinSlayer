using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOnTop : MonoBehaviour
{
    public float ForceImpulse = 10.0f;

    /// <summary>
    /// When toes´s player collide against enemy propel player in enemy direction
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && collision.name == "Toes")
        {
            collision.GetComponentInParent<Rigidbody2D>().AddForce(GetComponent<Rigidbody2D>().velocity.normalized * ForceImpulse, ForceMode2D.Impulse);
        }
    }


}
