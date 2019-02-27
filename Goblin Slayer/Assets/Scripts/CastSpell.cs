using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSpell : MonoBehaviour
{

    public GameObject projectile;
    public float impulseJump = 1.0f, throwRate = 1.5f;
    public bool isPlayer, meleeDistance;

    private Transform target;
    private Rigidbody2D rb;


    
    void Start ()
    {
        if(isPlayer)
        {
            CreateProjectile();
        }
        else//caso de ser un goblin
        {
            target = GameObject.Find("Player").transform;
            rb = GetComponent<Rigidbody2D>();
            InvokeRepeating("CreateProjectile",1.0f,throwRate);
        }
	}


    /// <summary>
    /// Crea el proyectil en la posición del padre
    /// </summary>
    public void CreateProjectile()
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
            //CreateProjectile();
        }
        else if (collision.tag == "Player" && transform.position.x < target.position.x)
        {
            rb.AddForce(new Vector2(-1f,1f)*impulseJump, ForceMode2D.Impulse);
            //CreateProjectile();
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            print("MODO MELEE");
            meleeDistance = true;
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            print("MODO CASTER");
            meleeDistance = false;
        }
    }

    public bool IsPlayer()
    {
        return isPlayer;
    }

    public bool IsChamanAtMelee()
    {
        return meleeDistance;
    }

}
