using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotLevelPAss : MonoBehaviour
{
    public float impulseForce;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !GameManager.instancia.IsGateOpen)
        {
            collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(-0.5f,0.5f)*impulseForce,ForceMode2D.Impulse);
        }
    }
}
