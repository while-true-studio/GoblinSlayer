using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Projectile projectile;
    public float cooldownTime = 0.8f;

    private Animator playerAnim;
    private Cooldown cooldown;
    private AttackSounds sounds;

    private void Start()
    {
        sounds = GetComponentInChildren<AttackSounds>();
        Init();
    }

    protected virtual void Init()
    {
        if (transform.childCount >= 1)
        {
            playerAnim = GetComponentInChildren<Animator>();
        }

        cooldown = new Cooldown(cooldownTime);
    }

    /// <summary>
    /// Crea el proyectil en la posición del padre
    /// </summary>
    private Projectile CreateProjectile()
    {
        //if (gameObject.tag == "Player")
        //    return Instantiate(projectile, transform.position, Quaternion.identity, fireBallPlayer);
        //else
        return Instantiate(projectile, transform.position, Quaternion.identity);
    }

    /// <summary>
    /// Shoots a <seealso cref="Projectile"/> in the given direction
    /// </summary>
    /// <param name="direction">The direction in wich the proyectile should shooted</param>
    public virtual void Shoot(Vector2 direction)
    {
        if (CanShoot())
        {
            sounds.PlayEffect(sounds.cast);
            ShootWork(direction);
        }
    }

    protected void ShootWork(Vector2 direction)
    {
        CastAnimator(direction);
        Projectile p = CreateProjectile();
        p.SetShooterTag(gameObject.tag);
        p.SetDirection(direction);
        p.ShootYourSelf();
        Debug.DrawLine(transform.position, direction, Color.red);
    }

    protected bool CanShoot()
    {
        return cooldown.CanUse();
    }

    protected virtual void CastAnimator(Vector2 dir)
    {
        if (playerAnim)
            playerAnim.SetTrigger("Cast");
    }
}