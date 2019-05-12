using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseAttack : MonoBehaviour
{
    MeleeAttacker melee;
    Projectile projectile;
    Shooter sh;
    private int protectileNormal;
    private float meleeNormal;
    public float MageIncrease;
    public float meleeIncrease;
    public float maxMelee;
    public float maxShooter;
    private float Shooter;
    public float mageNormal;


    void Awake()
    {

        melee = GetComponent<MeleeAttacker>();
        meleeNormal = melee.damage;
        sh = GetComponent<Shooter>();
       
    }

    public void MeleeControl()
    {
        if (melee.damage < maxMelee)
            melee.damage += meleeIncrease * Time.deltaTime;
    }
    public void MeleeInit()
    {
        melee.damage = meleeNormal;
    }

    public void MageControl()
    {
        if (Shooter < maxShooter)
        {
            Shooter += MageIncrease * Time.deltaTime;
        }


    }
    public void MageStop()
    {
        projectile = sh.projectile;
        Debug.Log(projectile.damage);
        projectile.damage = mageNormal;
        Debug.Log(projectile.damage);
        projectile.damage += Shooter;
        projectile.transform.localScale = new Vector3(2.5f + (Shooter/10.0f), 2.5f +( Shooter/10.0f), 1f + (Shooter / 10.0f));
        Debug.Log(projectile.damage);
    }
    public void MageInit()
    {

        Shooter = 0.0f;
    }




}
