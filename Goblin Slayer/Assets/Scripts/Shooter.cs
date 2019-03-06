using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    public Projectile projectile;
    public bool isPlayer, meleeDistance;



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
        Projectile p = CreateProjectile();
        p.SetDirection(direction);
        p.ShootYourSelf();

        Debug.Log("Shootong");
        Debug.DrawRay(transform.position, direction, Color.blue);
    }

    public bool IsPlayer()
    {
        return isPlayer;
    }

}
