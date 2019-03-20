using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Rage : MonoBehaviour {

    public int rageMax; //The maximun rage of the player
    public float currentRage;
    public float decreaseRageRate; //The rate to decrease the rage by time
    public float percentage;
    public float velBoost;
    public float dmgBoost;

    public enum State {NORMAL = 0, MASACRE = 1, SLAYER = 2};

    [Serializable]
    public struct RageBoost
    {
        public float vel;
        public float dmg;
    }

    [SerializeField]
    public State rageState;
    public RageBoost [] rageBoost;

    void Update()
    {
        percentage = (currentRage * 100) / rageMax;

        if (currentRage < 0) { currentRage = 0; }
        currentRage -= decreaseRageRate * Time.deltaTime;

        if (percentage < 40) rageState = State.NORMAL;
        else if (percentage >= 40 && percentage < 90) rageState = State.MASACRE;
        else if (percentage >= 90 && percentage <= 100) rageState = State.SLAYER;
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
