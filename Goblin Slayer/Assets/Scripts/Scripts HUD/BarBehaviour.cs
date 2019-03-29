using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarBehaviour : MonoBehaviour
{

    private Health health, healthBoss;
    private Mana mana;
    private Rage rage;
    public Scrollbar healthBar;
    public Scrollbar manaBar;
    public Transform rageBar;
    public Transform ragetext;
    //Scrollbar healthBossBar;
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        health = player.GetComponent<Health>();
        mana = player.GetComponent<Mana>();
        rage = player.GetComponent < Rage>();

        //Falta la barra de vida del Boss
    }

    void Update()
    {
        healthBar.size = (float)health.currentHealth / (float)health.maxHealth;
        manaBar.size = (float)mana.currentMana / (float)mana.maxMana;
        ragetext.GetComponent<Text>().text = ((int)rage.currentRage).ToString();
        rageBar.GetComponent<Image>().fillAmount = rage.currentRage / rage.rageMax;
    }    
}