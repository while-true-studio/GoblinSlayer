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



    void Awake()
    {
        if (!transform.parent.GetComponent<CastSpell>().IsPlayer())
        {
            target = GameObject.Find("Player").transform.position;
            rb = GetComponent<Rigidbody2D>();
            ShootProyectile();
        }

    }

    /// <summary>
    /// Asigna la dirección a la cual disparar
    /// </summary>
    /// <param name="direction"> Dirección a la que se quiere apuntar. </param>
    public void PlayerShooting(Vector2 direction)
    {
        shootDirection = direction;
        AddForceToProjectile();
    }

    public void AddForceToProjectile()
    {
        rb.AddForceAtPosition(shootDirection * projectileSpeed, target, ForceMode2D.Impulse);
        Destroy(gameObject, timeToDestroy);
    }

    /// <summary>
    /// Eligue entre disparo por velocidad o por impulso y aplica la fuerza correspondiente 
    /// </summary>
    public void ShootProyectile()
    {
        EstablishPlayerDirection();

        //en caso de estar a distancia melee contra el personaje
        if (transform.parent.GetComponent<CastSpell>().IsChamanAtMelee())
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            rb.velocity = shootDirection * projectileSpeed;
        }
        else
        {

            AddForceToProjectile();
        }
    }

    /// <summary>
    /// Establece la dirección en función de la posición del objetivo
    /// </summary>
    public void EstablishPlayerDirection()
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
            //aplicar daños al jugador
        }
        else if(collision.tag == "Enemy" && transform.parent.GetComponent<CastSpell>().IsPlayer())
        {
            Destroy(gameObject);
            //aplicar daños al goblin
        }
        else
        {
            Destroy(gameObject);
            //cuando choca contra un objecto del nivel
        }
    }

}
