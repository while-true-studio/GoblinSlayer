using System.Collections;
using UnityEngine;

public class Charge : MonoBehaviour
{
    public int Damage = 50;
    public int CooldownTime = 1500;
    public int Velocity = 5;
    public int Impulse = 50;

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
        if (charging || Time.time < nextAvailableChargeTime) return;
        Debug.Log("Charging");
        StartCoroutine(ChargeDirection(transform.position.x > other.transform.position.x
            ? Direction.Left
            : Direction.Right));
    }

    private IEnumerator ChargeDirection(Direction direction)
    {
        charging = true;
        var vector = (direction == Direction.Left ? Vector2.left : Vector2.right) * Velocity;
        Debug.Log(vector);
        while (charging)
        {
            rb.AddForce(vector, ForceMode2D.Force);
            yield return null;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // If it is not charging, ignore
        if (!charging) return;

        // If it collided with an attackable, deal damage
        var attackable = other.gameObject.GetComponent<Attackable>();
        if (!attackable) return;

        attackable.OnAttack(Damage);
        
        var impulse = new Vector2(other.GetContact(0).normal.x * -Impulse, 0.5f * Impulse);
        attackable.GetComponent<Rigidbody2D>().AddForce(impulse, ForceMode2D.Impulse);
        charging = false;
        nextAvailableChargeTime = Time.time + CooldownTime;
    }
}