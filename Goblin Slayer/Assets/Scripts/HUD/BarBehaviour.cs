using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarBehaviour : MonoBehaviour
{

    private Health health;
    private Mana mana;
    Scrollbar healthBar;
    Scrollbar manaBar;

    void Start()
    {
        GameObject player = GameObject.Find("Player");
        health = player.GetComponent<Health>();
        mana = player.GetComponent<Mana>();
        healthBar = transform.GetChild(1).GetChild(0).GetComponent<Scrollbar>();
        manaBar = transform.GetChild(2).GetChild(0).GetComponent<Scrollbar>();
        healthBar.size = 1;
        manaBar.size = 1;

    }

    void Update()
    {
        healthBar.size = (float) health.currentHealth/(float)health.maxHealth;
        manaBar.size = (float)mana.currentMana / (float)mana.maxMana;
    }


}
