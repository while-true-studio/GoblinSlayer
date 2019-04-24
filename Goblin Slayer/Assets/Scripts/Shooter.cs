using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    public Projectile projectile;
    public GameObject fireBallPool;
    public float cooldownTime = 0.8f;
    private Animator playerAnim;
  
    //private SpriteRenderer spriteRenderer;??
    private Cooldown cooldown;

    private void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        if (transform.childCount >= 1)
        {
            playerAnim = transform.GetChild(0).GetComponent<Animator>();

            //spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();??
        }

        cooldown = new Cooldown(cooldownTime);
    }

    /// <summary>
    /// Crea el proyectil en la posición del padre
    /// </summary>
    private Projectile CreateProjectile()
    {
        if (gameObject.tag == "Player")
        {
            return Instantiate(projectile, transform.position, Quaternion.identity, fireBallPool.transform);
        }
        else
        {
            return Instantiate(projectile, transform.position, Quaternion.identity, gameObject.transform);
        }
    }


    /// <summary>
    /// Shoots a <seealso cref="Projectile"/> in the given direction
    /// </summary>
    /// <param name="direction">The direction in wich the proyectile should shooted</param>
    public virtual void Shoot(Vector2 direction)
    {
        if (!cooldown.CanUse()) return;
        
        CastAnimator(direction);
        Projectile p = CreateProjectile();
        p.SetDirection(direction);
        p.ShootYourSelf();
        Debug.DrawLine(transform.position, direction, Color.red);
    }

    protected virtual void CastAnimator(Vector2 dir)
    {
        if(playerAnim)
            playerAnim.SetTrigger("Cast");
    }

}
