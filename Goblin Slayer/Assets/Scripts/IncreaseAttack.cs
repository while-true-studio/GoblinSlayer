using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseAttack : MonoBehaviour {
 MeleeAttacker melee;
    Projectile projectile;
    private int protectileNormal;
    private float meleeNormal  ;
    public float proyectileIncrease;
    public float meleeIncrease;
    public float maxMelee;
    public float maxShooter;
   
    float contador;
	void Awake()
    {
       
        melee = GetComponent<MeleeAttacker>();
        meleeNormal = melee.damage;
    }
    
    public void MeleeControl()
    {
        if (melee.damage < maxMelee )
            melee.damage +=meleeIncrease* Time.deltaTime;
    }
    public void MeleeStop()
    {

        melee.damage =meleeNormal;
    }

    public void MageControl(bool Increase)
    {projectile = GetComponent<Projectile>();
        if (projectile.damage < maxShooter)
            projectile.damage += meleeIncrease * Time.deltaTime;

    }
    public void MageStop()
    {

        melee.damage = meleeNormal;
    }




}
