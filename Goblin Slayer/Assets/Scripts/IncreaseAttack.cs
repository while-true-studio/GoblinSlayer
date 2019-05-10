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
    private float Shooter=0f;
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
    
    public void MageControl()
    {
       
       
            Shooter += meleeIncrease * Time.deltaTime;

    }
    public void MageStop()
    {
        projectile = GetComponent<Projectile>();
        projectile.damage += Shooter;
        Debug.Log(projectile.damage);
    }




}
