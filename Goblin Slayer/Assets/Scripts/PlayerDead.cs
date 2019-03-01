using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour, IDead
{
    void IDead.OnDead() 
    {
        Debug.Log("Imma player nad I'm Dead now :( *Ooof*");
    }
}
