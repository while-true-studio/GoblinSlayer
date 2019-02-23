using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour {


    private int manaMax = 1000; //Maná máximo del jugador
    private int mana = 50; //Indica el mana restante
    private int autoMana = 1; //Cantidad que regenerará el maná automáicamente
    private float regenRate = 1; //Tiempo que pasará entre cada regeneración
    private int fuegoMana = 200; //Cantidad de maná que se gastará al usar la magia de fuego
    private int aguaMana = 2; //Cantidad de maná que se ganará al usar la magia de agua


    /// <summary>
    /// Los siguientes métodos se usarán para poder utilizar
    /// las variables devueltas en otros scripts
    /// </summary>
    /// <returns>
    /// Cada uno retorna su respectiva variable
    /// </returns>
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
    public int FuegoMana()
    {
        return fuegoMana;
    }
    public int AguaMana()
    {
        return aguaMana;
    }
    
    
    
    /// <summary>
    /// Gastará o ganará maná según la magia usada
    /// </summary>
    /// <param name="magia">
    /// Indicará el tipo de magia usada. Si es fuego, gasta; si es agua, gana.
    /// </param>
    public void VariaMana(string magia)
    {
        if (magia == "fuego")
        {
            mana -= fuegoMana;
            print("Fuego: " + fuegoMana);
            print("Mana: " + mana);
        }
        else if (magia == "agua")
        {
            mana += aguaMana;
            if (mana > manaMax)
            {
                mana = manaMax;
            }
            print("Agua: " + aguaMana);
            print("Mana: " + mana);
        }

        print(mana);
    }

    /// <summary>
    /// La regenración automática del maná
    /// </summary>
    /// <param name="combate">
    /// Controla que el jugador no esté en combate para regenerar maná
    /// </param>
    public void AutoMana(bool combate)
    {
        if (mana < manaMax && !combate)
        {
            mana += autoMana;
            if (mana > manaMax)
            {
                mana = manaMax;
            }
            print("AutoReg: " + autoMana);
            print("Mana: " + mana);
        }
    }
}
