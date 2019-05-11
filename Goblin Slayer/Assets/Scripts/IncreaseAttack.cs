using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseAttack : MonoBehaviour {
 MeleeAttacker melee;
   private Projectile projectile;
    Shooter sh;
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
        sh = GetComponent<Shooter>();
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
        projectile = sh.projectile;
        projectile.damage += Shooter;
     projectile.transform.localScale = new Vector3(2.5f+Shooter, 2.5f+Shooter,1f+Shooter);
        Debug.Log(projectile.damage);
        Shooter = 0.0f;
    }




}
