using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rage : MonoBehaviour {

    public float rageMax; //The maximun rage of the player
    public float currentRage;
    public float decreaseRageRate; //The rate to decrease the rage by time
    public float percentage;

    void Update()
    {
        percentage = (currentRage * 100) / rageMax;
        currentRage -= decreaseRageRate * Time.deltaTime;
        if (currentRage < 0) currentRage = 0;
    }

    /// <summary>
    /// The currentRage will be plused by plusRage.
    /// </summary>
    public void ChangeRage(float addRage)
    {
        currentRage += addRage; 
        if (currentRage > rageMax) currentRage = rageMax;
    }   
}
