
using UnityEngine;

public class RageDoll : MonoBehaviour
{
    private Rigidbody2D rb;
    

	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        

	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Blocks"))
            rb.constraints = RigidbodyConstraints2D.FreezeAll;

    }
}
