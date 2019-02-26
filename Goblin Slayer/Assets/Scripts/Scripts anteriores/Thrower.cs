using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour
{
    public float timeToDestroy = 4.0f;
    public float projectileSpeed = 1.0f;

    private Transform target;
    private Rigidbody2D rb;
    private Vector2 shootDirection;
    public bool modoProjectile;


    private void Awake()
    {
        target = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        modoProjectile = transform.parent.GetComponent<CastSpell>().AttackStatus();
    }

    void Start()
    {

        EstablishDirection();
        ShootProyectile();

        Destroy(gameObject, timeToDestroy);
    }

    /// <summary>
    /// Eligue entre disparo por velocidad o por impulso y aplica la fuerza correspondiente 
    /// </summary>
    public void ShootProyectile()
    {
        if(!modoProjectile)
        {
            rb.AddForceAtPosition(shootDirection * projectileSpeed, target.position, ForceMode2D.Impulse);

            //rb.AddForce(shootDirection * projectileSpeed,ForceMode2D.Impulse);
        }
        else
        {
            projectileSpeed = projectileSpeed / 2;
            rb.AddForceAtPosition(shootDirection * projectileSpeed, target.position, ForceMode2D.Impulse);
        }
    }

    /// <summary>
    /// Establece la dirección en función de la posición del objetivo
    /// </summary>
    public void EstablishDirection()
    {
        if (transform.position.x > target.position.x)
        {
            shootDirection = new Vector2(-1f, 1f);
            transform.right = Vector2.left;
        }
        else if (transform.position.x < target.position.x)
        {
            shootDirection = Vector2.one;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "Player")
        {
            Destroy(gameObject);
            //aplicar daños
        }
        else if(collision.tag!="Enemy")
        {
            Destroy(gameObject);
        }
    }

}
