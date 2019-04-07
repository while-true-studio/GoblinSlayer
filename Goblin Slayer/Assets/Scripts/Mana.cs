using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour {

    
    public float maxMana = 100; 
    public float currentMana;
    public float autoManaRegenRate;
    private void Start()
    {
        currentMana = maxMana;
    }
    private void Update()
    {
        currentMana += autoManaRegenRate * Time.deltaTime;
        if (currentMana > maxMana)
        {
            currentMana = maxMana;
        }
    }

    public bool UseMana(float spellCost)
    {
        if (currentMana - spellCost < 0) return false;
        currentMana -= spellCost;
        return true;
    }

}
