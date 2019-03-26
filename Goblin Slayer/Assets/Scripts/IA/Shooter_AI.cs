using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Shooter))]
public class Shooter_AI : MonoBehaviour, IAttacker_AI
{
    private Shooter shooter;
    private void Start()
    {
        shooter = GetComponent<Shooter>();
    }

    public void Attack(Transform target)
    {
        float angle;
        if (CalculateShootingAngle(target,1,  out angle))
        {
            Vector2 dir = Quaternion.AngleAxis(angle, new Vector3(0, 0, 1)) * Vector3.right;
            shooter.Shoot(dir);
        }
    }
    /// <summary>
    /// Calculates, if posible, the best angle to shoot a projectile to reach the target
    /// </summary>
    /// <param name="target">The target to aim</param>
    /// <param name="projectileVelocity">The initial velocity of the projetile throwing</param>
    /// <param name="angle">The optimal angle to shoot the projectile</param>
    /// <returns>True if is posible to reach the target, false otherwise</returns>
    bool CalculateShootingAngle(Transform target, float projectileVelocity, out float angle)
    {
        //Maximum theorical distance
        float maxDistance = (projectileVelocity * projectileVelocity) / Physics.gravity.magnitude;
        //If we exceeded that distance the shoot is impoible
        if (Vector2.Distance(target.position, transform.position) > maxDistance)
        {
            //The shoot is imposible
            angle = float.NaN;
            return false;
        }
        //float x = target.position.x - transform.position.x;
        //TODO: this shit paso de hacer las cuentas estas ahora
        angle = Mathf.Deg2Rad * 45;
        return true;
    }
}
