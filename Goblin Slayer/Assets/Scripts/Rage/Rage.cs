using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[RequireComponent(typeof(Walker))]
[RequireComponent(typeof(MeleeAttacker))]
[RequireComponent(typeof(Projectile))]
public class Rage : MonoBehaviour {

    public int rageMax; //The maximun rage of the player
    public float currentRage;
    public float decreaseRageRate; //The rate to decrease the rage by time
    public float percentage; //The percentage of the currentRage in function of rageMax

    Walker walker; //The script that contains the velocity of the player character
    MeleeAttacker melee; //The script that contains the dmg melee of the player character
    Projectile mageProjectile; //The script that contains the dmg mage of the player character
    float initialVel; //The initial velocity of the script Walker
    int initialDmgMelee; //The initial dmg of the melee mode
    int initialDmgMage; //The initial dmg of the mage mode

    public enum State {NORMAL = 0, MASACRE = 1, SLAYER = 2};
    
    [Serializable]
    public struct RageBoost
    {
        public int vel;
        public int dmgMelee;
        public int dmgMage;
    }

    [SerializeField]
    public State rageState;
    public RageBoost [] rageBoost;

    private void Start()
    {
        walker = GameObject.Find("Player").GetComponent<Walker>();
        melee = GameObject.Find("Player").GetComponent<MeleeAttacker>();
        mageProjectile = GameObject.Find("Player").GetComponent<Projectile>();

        initialVel = walker.velocity;
        initialDmgMelee = melee.damage;
        initialDmgMage = mageProjectile.damage;
    }
    void Update()
    {
        percentage = (currentRage * 100) / rageMax;
        currentRage -= decreaseRageRate * Time.deltaTime;

        if (currentRage < 0) currentRage = 0;
        

        if (percentage < 40) rageState = State.NORMAL;
        else if (percentage >= 40 && percentage < 90) rageState = State.MASACRE;
        else if (percentage >= 90 && percentage <= 100) rageState = State.SLAYER;

        AddBoost(walker, melee, mageProjectile, rageBoost[Convert.ToInt32(rageState)]);
    }

    /// <summary>
    /// The currentRage will be added by plusRage.
    /// </summary>
    public void AddRage(int plusRage)
    {
        currentRage += plusRage; 
        if (currentRage > rageMax) currentRage = rageMax;
    }

    public void AddBoost(Walker walker, MeleeAttacker dmgMelee, Projectile dmgMage, RageBoost rageBoost)
    {
        walker.velocity = initialVel + rageBoost.vel;
        dmgMelee.damage = initialDmgMelee + rageBoost.dmgMelee;
        dmgMage.damage = initialDmgMage + rageBoost.dmgMage;
     }
}
