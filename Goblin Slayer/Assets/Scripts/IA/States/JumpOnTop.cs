using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class JumpOnTop : MonoBehaviour
{
    public float ForceImpulse = 10.0f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// When toes´s player collide against enemy propel player in enemy direction
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.name == "Toes")
        {
            collision.GetComponentInParent<Rigidbody2D>()
                .AddForce(rb.velocity.normalized * ForceImpulse, ForceMode2D.Impulse);
        }
    }
}