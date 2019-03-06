using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ManaController : MonoBehaviour
{
    //There is an error
    /*
     * NullReferenceException: Object reference not set to an instance of an object
        ManaController.Start () (at Assets/Scripts/Scripts HUD/ManaController.cs:17)

        NullReferenceException: Object reference not set to an instance of an object
        ManaController.Update () (at Assets/Scripts/Scripts HUD/ManaController.cs:25)
        
         The manaBar works like we hope, but It stil having an unkwon error*/
         
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
