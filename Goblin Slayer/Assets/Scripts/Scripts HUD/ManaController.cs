using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ManaController : MonoBehaviour
{
    Mana mana;
    float regenMana, testMana;//This testMana will be change to fireMana, aquaMana and windMana. 
    Scrollbar manaBar;

    void Start()
    {
        mana = GetComponent<Mana>();
        manaBar = GetComponent<Scrollbar>();
        mana.maxMana = manaBar.size;
        mana.currentMana = mana.maxMana;
        mana.autoManaRegenRate = manaBar.size * 0.2f;
        testMana = manaBar.size * 0.1f;
    }

    void Update()
    {
        manaBar.size = mana.currentMana;
    }

    public void WasteMana()
    {
        mana.UseMana(testMana);
    }
}
