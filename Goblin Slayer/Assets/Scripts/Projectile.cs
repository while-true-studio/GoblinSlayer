using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    public float projectileSpeed = 1.0f;
    private Rigidbody2D rb;
    private Vector2 shootDirection;
    public float damage = 45;
    public float projectileRotation = 1.5f;
    private Animator animator;
    private string ownerTag;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //?????Por qué está esto en el update??????????
        if(shootDirection.x > 0.0f)
        {
            transform.Rotate(new Vector3(0.0f,0.0f,-0.7f));
        }
        else
        {
            transform.Rotate(new Vector3(0.0f, 0.0f, 0.7f));
        }
    }

    /// <summary>
    /// Set the direction to shoot
    /// </summary>
    /// <param name="direction"></param>
    public void SetDirection(Vector2 direction)
    {
        shootDirection = direction;
    }

    /// <summary>
    /// Activate a initial velocity 
    /// </summary>
    public void ShootYourSelf()
    {
        transform.right = shootDirection;
        rb.AddForce(shootDirection * projectileSpeed,ForceMode2D.Impulse);
    }

    public void SetShooterTag(string tag)
    {
        ownerTag = tag;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ownerTag) return;


        Attackable target = collision.gameObject.GetComponent<Attackable>();


        if (target != null)
        {
            GetComponent<Collider2D>().enabled = false;
            target.OnAttack(damage);
        }
        DestroyProjectil();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Shield")
        {
            DestroyProjectil();
        }
    }

    private void DestroyProjectil()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        Destroy(gameObject, 0.5f);
        animator.SetTrigger("Destroy");
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.LogFormat("Collision of {0} with {1}", gameObject.name, collision.gameObject.name);

    }

}
