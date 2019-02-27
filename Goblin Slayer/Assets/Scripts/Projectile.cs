using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed = 1.0f;
    private Rigidbody2D rb;
    private Vector2 shootDirection;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Set the direction to shoot
    /// </summary>
    /// <param name="direction"></param>
    public void SetDirection(Vector2 direction)
    {
        this.shootDirection = direction;
    }
    
    /// <summary>
    /// Activate a initial velocity 
    /// </summary>
    public void ShootYourSelf()
    {
        rb.velocity = shootDirection * projectileSpeed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Attackable target = collision.gameObject.GetComponent<Attackable>();
        if (target && collision.tag != transform.tag)
        {
            target.ReciveDmg(damage);
        }
        Destroy(gameObject);
    }

}
