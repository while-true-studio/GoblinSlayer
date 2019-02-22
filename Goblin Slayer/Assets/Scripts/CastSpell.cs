using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSpell : MonoBehaviour
{

    public GameObject projectile;
    public float impulseJump = 1.0f, throwRate = 1.5f;
    public bool isPlayer;

    private Transform target;
    private Rigidbody2D rb;



    void Start ()
    {
        if(isPlayer)
        {
            Instantiate(projectile, transform.position, Quaternion.identity, gameObject.transform);
        }
        else//caso de ser un goblin
        {
            InvokeRepeating("ShootProjectile", 1f, throwRate);
            target = GameObject.Find("Player").transform;
            rb = GetComponent<Rigidbody2D>();
        }
	}


    /// <summary>
    /// Crea el proyectil en la posición del padre
    /// </summary>
    public void ShootProjectile()
    {
        Instantiate(projectile, transform.position, Quaternion.identity, gameObject.transform);
    }

    /// <summary>
    /// Impulsa al goblin hacia atras cuando el personaje entra en el trigger
    /// </summary>
    /// <param name="collision"></param>
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
            /*float aux = throwRate;
            throwRate = 0.5f;
            CancelInvoke();
            InvokeRepeating("ShootProjectile", 0.1f, throwRate);
            throwRate = aux;*/
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            print("MODO CASTER");
            /*CancelInvoke();
            InvokeRepeating("ShootProjectile", 0.1f, throwRate);*/
        }
    }

    public bool IsPlayer()
    {
        return isPlayer;
    }



}
