using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseAttack : MonoBehaviour {

    Projectile projectile;
    private int protectileNormal;
    private int meleeNormal;
    public float proyectileIncrease;
    public float meleeIncrease;
    public float maxMelee;
    public float maxShooter;
    MeleeAttacker melee;
	void Start()
    {
       
        melee = GetComponent<MeleeAttacker>();
        meleeNormal = melee.damage;

    }
    public void MeleeControl(bool Increase)
    {
        if (melee.damage < maxMelee && Increase)
            melee.damage += (int)Time.time;
       else if (!Increase) melee.damage = meleeNormal;
    }
    public void MageControl(bool Increase)
    {
        if (projectile.damage < maxMelee && Increase)
            melee.damage += (int)Time.time;
       else if (!Increase) melee.damage = meleeNormal;
    }
  



}
