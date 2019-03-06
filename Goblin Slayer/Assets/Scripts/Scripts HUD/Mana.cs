using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{


    public float maxMana;
    public float currentMana;
    public float autoManaRegenRate;

    private void Update()
    {
        currentMana += autoManaRegenRate * Time.deltaTime;
        if (currentMana > maxMana) currentMana = maxMana;
        else if (currentMana < 0) currentMana = 0;
    }

    public void UseMana(float spellCost)
    {
        if (spellCost <= currentMana)
            currentMana -= spellCost;
    }

}