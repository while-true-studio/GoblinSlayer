using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rage : MonoBehaviour {

    public int rageMax; //The maximun rage of the player
    public float currentRage;
    public float decreaseRageRate; //The rate to decrease the rage by time
   

    void Update()
    {
        if (currentRage < 0) currentRage = 0;
        currentRage -= decreaseRageRate * Time.deltaTime;        
    }

    /// <summary>
    /// The currentRage will be plused by plusRage.
    /// </summary>
    public void AddRage(int plusRage)
    {
        currentRage += plusRage; 
        if (currentRage > rageMax) currentRage = rageMax;
    }   
}
