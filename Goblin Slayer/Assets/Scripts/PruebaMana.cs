using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaMana : MonoBehaviour {
    /// <summary>
    /// Este script está diseñado para probar la funcionalidad
    /// del script Mana, comprobando que sume cuando se usa la magia de agua
    /// y que reste cuando se usa la de fuego, además de la Autoregeneración
    /// </summary>
    private Mana mana;	

	void Start ()
    {
        mana = gameObject.GetComponent<Mana>();        
	}
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && mana.ManaRestante() >= mana.FuegoMana())
        {
            mana.VariaMana("fuego");
        }
        else if (Input.GetKey(KeyCode.Mouse1) && mana.ManaRestante() <= mana.ManaMax())
        {
            mana.VariaMana("agua");
        }

        mana.AutoMana(false);
	}
}
