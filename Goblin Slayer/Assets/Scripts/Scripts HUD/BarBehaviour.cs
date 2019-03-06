using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarBehaviour : MonoBehaviour
{

    private Health health, healthBoss;
    private Mana mana;    
    Scrollbar healthBar;
    Scrollbar manaBar;
    //Scrollbar healthBossBar;
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        health = player.GetComponent<Health>();
        mana = player.GetComponent<Mana>();        
         
        // healthBoss = GameObject.Find("Boss").GetComponent<Health>();
        

        //To use the three following lines It is absolutely necessary that 
        //healthBar, manaBar and healthBossBar are one below the other in the Hierarchy.
        healthBar = transform.GetChild(0).transform.GetChild(0).GetComponent<Scrollbar>(); 
        manaBar = transform.GetChild(1).transform.GetChild(0).GetComponent<Scrollbar>();
        //healthBossBar = transform.GetChild(2).transform.GetChild(0).GetComponent<Scrollbar>();

        healthBar.size = 1;
        manaBar.size = 1;
        //healthBossBar = 1;
    }

    void Update()
    {
        healthBar.size = (float)health.currentHealth / (float)health.maxHealth;
        manaBar.size = (float)mana.currentMana / (float)mana.maxMana;
    }    
}