using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaMana : MonoBehaviour {
    
    /* Este script está diseñado para probar la funcionalidad
     del script Mana, comprobando que sume cuando se usa la magia de agua
     y que reste cuando se usa la de fuego, además de la Autoregeneración*/

    private Mana mana;
    public int fuegoMana = 200; //Cantidad de maná que se gastará al usar la magia de fuego
    public int aguaMana = 2; //Cantidad de maná que se ganará al usar la magia de agua

    void Start ()
    {
        mana = gameObject.GetComponent<Mana>();        
	}
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && mana.GastaMana(fuegoMana))
        {
            mana.mana -= fuegoMana;
            print("Fuego: " + fuegoMana);
            print("Maná Restante: " + mana.ManaRestante());
        }
        else if (Input.GetKey(KeyCode.Mouse1) && mana.ManaRestante() < mana.ManaMax())
        {
            mana.AquaMagic(aguaMana);
            print("Agua: " + aguaMana);
            print("Maná Restante: " + mana.ManaRestante());
        }

        mana.RegMana();
        print("AutoReg: " + mana.AutoMana());
        print("Mana: " + mana.ManaRestante());
    }
}
