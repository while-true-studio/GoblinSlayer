using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour
{
    public float timeToDestroy = 4.0f;
    public float projectileSpeed = 1.0f;

    private Vector2 target;
    private Rigidbody2D rb;
    private Vector2 shootDirection;



    void Start()
    {
        if (transform.parent.GetComponent<CastSpell>().IsPlayer())
        {
            //traer dirección desde player controller
            print("PIM PIM FIRE");
        }
        else
        {
            target = GameObject.Find("Player").transform.position;
            rb = GetComponent<Rigidbody2D>();
            EstablishDirection();
            ShootProyectile();
            Destroy(gameObject, timeToDestroy);
        }

    }

    /// <summary>
    /// Eligue entre disparo por velocidad o por impulso y aplica la fuerza correspondiente 
    /// </summary>
    public void ShootProyectile()
    {
        rb.AddForceAtPosition(shootDirection * projectileSpeed, target, ForceMode2D.Impulse);
    }

    /// <summary>
    /// Establece la dirección en función de la posición del objetivo
    /// </summary>
    public void EstablishDirection()
    {
        if (transform.position.x > target.x)
        {
            shootDirection = new Vector2(-1f, 1f);
            transform.right = Vector2.left;
        }
        else if (transform.position.x < target.x)
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
