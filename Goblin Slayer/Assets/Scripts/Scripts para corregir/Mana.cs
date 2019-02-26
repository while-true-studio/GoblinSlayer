using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour {


    //Variables públicas
    public int manaMax; //Maná máximo del jugador
    public int mana = 50; //Indica el mana restante
    public int autoMana = 1; //Cantidad que regenerará el maná automáicamente
    public float regenRate = 1; //Tiempo que pasará entre cada regeneración
   
     
    //Métodos públicos para usarlos en otras clases
    public int ManaMax()
    {
        return manaMax;
    }
    public int ManaRestante()
    {
        return mana;
    }
    public int AutoMana()
    {
        return autoMana;
    }
    public float RegenRate()
    {
        return regenRate;
    }       
    
    /// <summary>
    /// Devolverá true si el coste del hechizo usado es menor o igual
    /// al maná restante. 
    /// </summary>
    /// <param name="cost">
    /// Indicará la cantidad de maná usada.
    /// </param>
    public bool GastaMana(int cost)
    {
        return cost <= mana;       
    }

    /// <summary>
    /// Sumará maná al maná restante cuando se use la magia agua
    /// </summary>
    /// <param name="cost">
    /// Será la cantidad que se sume al maná restante al usar la magia de agua
    /// </param>
    public void AquaMagic(int cost)
    {
        mana += cost;
    }

    /// <summary>
    /// La regeneración automática del maná
    /// </summary>
    public void RegMana()
    {
        if (mana < manaMax)
        {
            mana += autoMana;
        }
        else
        {
            mana = manaMax;
        }
    }
}
