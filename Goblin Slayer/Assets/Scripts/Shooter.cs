using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    public Projectile projectile;
    private Mana mana;
    public float manaCost = 20.0f;
    public bool isPlayer;
    private Animator playerAnim;
    private Animator effectAnim;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        mana = GetComponent<Mana>();
        playerAnim = transform.GetChild(0).GetComponent<Animator>();

        if (GetComponent<PlayerController>())
        {
            effectAnim = transform.GetChild(1).GetComponent<Animator>();
        }

        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }
    /// <summary>
    /// Crea el proyectil en la posición del padre
    /// </summary>
    private Projectile CreateProjectile()
    {
        return Instantiate(projectile, transform.position, Quaternion.identity, gameObject.transform);
    }


    /// <summary>
    /// Create a proyectile in transform position
    /// </summary>
    /// <param name="direction"></param>
    public void Shoot(Vector2 direction)
    {
        
        if(mana.UseMana(manaCost))
        {
            CastAnimator(direction);
            Projectile p = CreateProjectile();
            p.SetDirection(direction);
            p.ShootYourSelf();
            Debug.DrawLine(transform.position, direction, Color.red);
        }
        else
        {
            print("not enough mana");
        }

    }

    public bool IsPlayer()
    {
        return isPlayer;
    }

    public LayerMask SetCollisionMask()
    {
        return GetComponent<LayerMask>();
    }

    private void CastAnimator(Vector2 dir)
    {
        if (dir.normalized.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if(dir.normalized.x < 0)
        {
            spriteRenderer.flipX = false;
        }

        playerAnim.SetTrigger("Cast");

        if(GetComponent<PlayerController>())
        {
            effectAnim.SetTrigger("Casting");
        }

    }

}
