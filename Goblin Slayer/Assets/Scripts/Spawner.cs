using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    /// <summary>
    /// The GameObject prefab this Spawner should instantiate.
    /// </summary>
    public GameObject unit;

    /// <summary>
    /// The bucket for this spawner, this equals to the amount
    /// of `unit` clones this will create.
    /// </summary>
    public short remaining = 20;

    /// <summary>
    /// The time interval in seconds for the spawner, an higher
    /// amount means more time between spawns.
    /// </summary>
    public float spawnInterval = 3.5f;
    
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
        while (remaining-- != 0)
        {
            Instantiate(unit, transform.position, Quaternion.identity, transform);
            yield return new WaitForSeconds(spawnInterval);
        }

        // Set enabled to false to prevent further CPU usage.
        enabled = false;
    }

}
