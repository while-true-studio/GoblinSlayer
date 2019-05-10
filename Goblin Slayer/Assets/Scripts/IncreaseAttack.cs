using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseAttack : MonoBehaviour {
 MeleeAttacker melee;
    Projectile projectile;
    private int protectileNormal;
    public float meleeNormal = 10f ;
    public float proyectileIncrease;
    public float meleeIncrease;
    public float maxMelee;
    public float maxShooter;
   
    float contador;
	void Start()
    {
       
        melee = GetComponent<MeleeAttacker>();
      
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
    {
        if (projectile.damage < maxMelee && Increase)
            melee.damage += (int)Time.time;
       else if (!Increase) melee.damage = meleeNormal;
    }
  



}
