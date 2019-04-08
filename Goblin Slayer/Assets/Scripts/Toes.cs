using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toes : MonoBehaviour
{
    public bool onGound { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision){if (collision.tag == "Blocks") { onGound = true; }}

    private void OnTriggerExit2D(Collider2D collision) { if (collision.tag == "Blocks") { onGound = false; } }

    /*private void OnCollisionEnter2D(Collision2D collision){ if (collision.gameObject.tag == "Blocks") }

    private void OnCollisionExit2D(Collision2D collision) { if (collision.gameObject.tag == "Blocks") { onGound = false; } }*/

}
