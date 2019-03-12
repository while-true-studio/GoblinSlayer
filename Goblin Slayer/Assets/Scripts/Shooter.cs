using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    public Projectile projectile;
    private Mana mana;
    public float manaCost = 20.0f;
    public bool isPlayer, meleeDistance;


    private void Start()
    {
        mana = GetComponent<Mana>();
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

}
