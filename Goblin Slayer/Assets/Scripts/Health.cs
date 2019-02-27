using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;
    public bool Alive { get; private set; }
    
    /// <summary>
    /// Applies damage and updates the gameObject's status (alive/dead)
    /// </summary>
    /// <param name="amount"> Amount of damage </param>
    public void LoseHealth(int amount)
    {
        currentHealth -= amount;
        Alive = !Dead();
    }

    /// <summary>
    /// Método que comprueba si el jugador esta vivo o muerto
    /// </summary>
    /// <returns></returns>
    public bool Dead()
    {
        return currentHealth <= 0;
    }


    /// <summary>
    /// Método recupera el HP, y comprueba que esté entre los parámetros
    /// </summary>
    /// <param name="amount"> Cantidad de vida que recupera </param>
    public void RestoreHP(int amount)
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += amount;
        }
        EqualHP();
    }

    /// <summary>
    /// Método que iguala la salud al máximo posible en caso de pasarse del límite
    /// </summary>
    public void EqualHP()
    {
        if (currentHealth > maxHealth) currentHealth = maxHealth;
    }

    /// <summary>
    /// Devuelve el HP actual
    /// </summary>
    /// <returns></returns>
    public int GetHP()
    {
        return currentHealth;
    }
}
