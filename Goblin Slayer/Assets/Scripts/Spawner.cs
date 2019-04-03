using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [System.Serializable]
    public struct UnitType
    {
        public GameObject GameObject;
        public uint Amount;
    }

    /// <summary>
    /// The list of GameObjects with their amounts this Spawner should instantiate. 
    /// </summary>
    public List<UnitType> unitTypes;

    /// <summary>
    /// The time interval in seconds for the spawner, an higher
    /// amount means more time between spawns.
    /// </summary>
    public float spawnInterval = 0.5f;
    
    /// <summary>
    /// Start the spawning coroutine.
    /// </summary>
    public void Spawn()
    {
        StartCoroutine(OnSpawn());
    }

    /// <summary>
    /// Coroutine that spawns a `unit` object every `spawnInterval` seconds using
    /// its bucket until it empties, then it gets self destroyed.
    /// </summary>
    /// <returns>The IEnumerator for the coroutine.</returns>
    private IEnumerator OnSpawn()
    {
        foreach (UnitType unitType in unitTypes)
        {
            for (int i = 0; i < unitType.Amount; i++)
            {
                Instantiate(unitType.GameObject, transform.position, Quaternion.identity, transform);
                yield return new WaitForSeconds(spawnInterval);
            }
        }

        // Set enabled to false to prevent further CPU usage.
        enabled = false;
    }

}
