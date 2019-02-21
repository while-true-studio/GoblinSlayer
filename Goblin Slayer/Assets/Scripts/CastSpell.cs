using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSpell : MonoBehaviour
{

    public GameObject projectile;
    public float impulseJump = 1.0f, throwRate = 1.5f;
    private Transform target;
    private Rigidbody2D rb;
    private bool melee = false;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start ()
    {
        InvokeRepeating("ShootProjectile",1f,throwRate);
        target = GameObject.Find("Player").transform;
	}


    /// <summary>
    /// Crea el proyectil en la posición del padre
    /// </summary>
    public void ShootProjectile()
    {
        Instantiate(projectile, transform.position, Quaternion.identity, gameObject.transform);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && transform.position.x > target.position.x)
        {
            rb.AddForce(Vector2.one*impulseJump,ForceMode2D.Impulse);
        }
        else if (collision.tag == "Player" && transform.position.x < target.position.x)
        {
            rb.AddForce(new Vector2(-1f,1f)*impulseJump, ForceMode2D.Impulse);
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            print("MODO MELEE");
            float aux = throwRate;
            throwRate = 0.5f;
            CancelInvoke();
            InvokeRepeating("ShootProjectile", 0.1f, throwRate);
            throwRate = aux;
            melee = true;
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            print("MODO CASTER");
            CancelInvoke();
            InvokeRepeating("ShootProjectile", 0.1f, throwRate);
            melee = false;
        }
    }

    /// <summary>
    /// returna el actual modo de ataque 
    /// </summary>
    /// <returns></returns>
    public bool AttackStatus()
    {
        return melee;
    }
}
