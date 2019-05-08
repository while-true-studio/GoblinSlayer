using System.Collections;
using UnityEngine;

public class Charge : MonoBehaviour
{
    public int Damage = 50;
    public int CooldownTime = 1500;
    public int Velocity = 5;

    private enum Direction
    {
        Left,
        Right
    }

    private Rigidbody2D rb;
    public bool charging;
    public float nextAvailableChargeTime;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        nextAvailableChargeTime = Time.time;
    }

    public void ChargeAt(Transform other)
    {
        Debug.Log("Trying to charge...");
        if (charging || Time.time < nextAvailableChargeTime) return;
        Debug.Log("Charging");
        StartCoroutine(ChargeDirection(transform.position.x > other.transform.position.x
            ? Direction.Left
            : Direction.Right));
    }

    private IEnumerator ChargeDirection(Direction direction)
    {
        charging = true;
        var vector = direction == Direction.Left ? Vector2.left : Vector2.right;
        while (charging)
        {
            rb.AddForce(vector, ForceMode2D.Impulse);
            yield return null;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Touched something... am I charging?");
        // If it is not charging, ignore
        if (!charging) return;
        Debug.Log(string.Format("Touched something, with the tag of {0}", other.gameObject.tag));

        // If it collided with an attackable, deal damage
        var attackable = other.gameObject.GetComponent<Attackable>();
        if (attackable)
        {
            attackable.OnAttack(Damage);
            charging = false;
            nextAvailableChargeTime = Time.time + CooldownTime;
        }
    }
}