using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarBehaviour : MonoBehaviour
{

    private Health health;
    private Mana mana;
    private Rage rage;
    public Scrollbar healthBar;
    public Scrollbar manaBar;
    public Transform rageBar;
    public Text ragetext;
    public Text rageModeText;

    //private Health healthBoss;
    //Scrollbar healthBossBar;
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        health = player.GetComponent<Health>();
        mana = player.GetComponent<Mana>();
        rage = player.GetComponent <Rage>();

        //Falta la barra de vida del Boss
        //healthBoss = GameObject.Find("Boos").GetComponent<Health>();
    }

    void Update()
    {
        healthBar.size = ((float)health.currentHealth / (float)health.maxHealth);
        manaBar.size = ((float)mana.currentMana / (float)mana.maxMana);
        ragetext.text = (int)rage.percentage + "%";
        rageBar.GetComponent<Image>().fillAmount = rage.currentRage / rage.rageMax;
        if (rage.rageState == Rage.State.NORMAL) rageModeText.text = "NORMAL MODE";
        else if (rage.rageState == Rage.State.MASACRE) rageModeText.text = "MASACRE MODE";
        else if (rage.rageState == Rage.State.SLAYER) rageModeText.text = "SLAYER MODE";
    }    
}