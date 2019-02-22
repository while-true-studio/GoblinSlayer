using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour {


    public int manaMax; //Maná máximo del jugador
    public int mana; //Variable que cambiará el nivel de maná según lo que ocurra
    public int autoMana; //Cantidad que regenerará el maná automáicamente
    public float regenRate = 1; //Tiempo que pasará entre cada regeneración
    public int gastoMana; //Cantidad de maná que se gastará al usar una habilidad
    public int ganaMana; //Cantidad de maná que se ganará al usar la magia de agua
  
    void Start()
    {
        //Iniciará la recuperación automática de maná.
        InvokeRepeating("AutoMana", 1.0f, regenRate);
    }

    /// <summary>
    /// Gastará o ganará maná según la magia usada
    /// </summary>
    /// <param name="magia">
    /// Indicará el tipo de magia usada. Si es fuego, gasta; si es agua, gana.
    /// </param>
    public void VariaMana(string magia)
    {
        if (magia == "fuego") mana -= gastoMana;
        else if (magia == "agua") mana += ganaMana;
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
            mana += autoMana;
    }
}
