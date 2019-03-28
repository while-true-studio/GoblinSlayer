using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinDead : MonoBehaviour, IDead
{
    void IDead.OnDead()
    {
        Debug.Log("Imma Goblin and i'm ded. I'd like to keep raping but I need to go, bye");
        Destroy(gameObject);
    }
}
