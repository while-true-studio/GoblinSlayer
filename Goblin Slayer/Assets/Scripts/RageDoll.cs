using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RageDoll : MonoBehaviour
{
    private Rigidbody2D rb;
    

	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        if (CompareTag("Player"))
        {
            GameManager.instancia.ResetScene(4);
        }

	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Blocks"))
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
