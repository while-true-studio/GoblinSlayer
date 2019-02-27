using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaMana : MonoBehaviour {
    
    /* Este script está diseñado para probar la funcionalidad
     del script Mana, comprobando que sume cuando se usa la magia de agua
     y que reste cuando se usa la de fuego, además de la Autoregeneración*/

    private Mana mana;
    public float fuegoMana; //Cantidad de maná que se gastará al usar la magia de fuego
    public float aguaMana; //Cantidad de maná que se ganará al usar la magia de agua

    void Start ()
    {
        mana = gameObject.GetComponent<Mana>();        
	}
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && mana.UseMana(fuegoMana))
        {
            print("Fuego: " + fuegoMana);
            print("Current Mana: " + mana.currentMana);
        }
        else if (Input.GetKey(KeyCode.Mouse1) && mana.UseMana(aguaMana))
        {            
            print("Agua: " + -aguaMana);
            print("Maná Restante: " + mana.currentMana);
        }        
    }
}
