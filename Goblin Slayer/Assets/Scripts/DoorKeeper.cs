using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKeeper : MonoBehaviour
{
    public int spawnsNum;
    private GameObject[] spawns;

	void Start ()
    {
        spawns = GameObject.FindGameObjectsWithTag("Spawn");
        spawnsNum = spawns.Length;
	}

    /// <summary>
    /// Remove when player destroy a spawner
    /// </summary>
    public void RemoveSpawn()
    {
        spawnsNum -= 1;
        if(spawnsNum==0){OpenNextLvl();}
    }

    /// <summary>
    /// Disable collider and sprite of the gate
    /// </summary>
    private void OpenNextLvl()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    /// <summary>
    /// Load next level
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.instancia.ChangeScene(0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("You must kill all goblins before go to the next lvl ");
    }
}
