using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    public Projectile projectile;
    public float manaCost = 20.0f;
    public float cooldownTime = 0.8f;
    private Mana mana;
    private Animator playerAnim;
    private Animator effectAnim;
    private SpriteRenderer spriteRenderer;
    private Cooldown cooldown;

    private void Start()
    {
        mana = GetComponent<Mana>();
        playerAnim = transform.GetChild(0).GetComponent<Animator>();

        if (GetComponent<PlayerController>())
        {
            effectAnim = transform.GetChild(1).GetComponent<Animator>();
        }

        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        cooldown = new Cooldown
        {
            cooldown = cooldownTime
        };
    }
    /// <summary>
    /// Crea el proyectil en la posición del padre
    /// </summary>
    private Projectile CreateProjectile()
    {
        return Instantiate(projectile, transform.position, Quaternion.identity, gameObject.transform);
    }


    /// <summary>
    /// Shoots a <seealso cref="Projectile"/> in the given direction
    /// </summary>
    /// <param name="direction">The direction in wich the proyectile should shooted</param>
    public void Shoot(Vector2 direction)
    {
        if (!cooldown.CanUse()) return;
        if (mana.UseMana(manaCost))
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

    public LayerMask SetCollisionMask()
    {
        return GetComponent<LayerMask>();//???
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
