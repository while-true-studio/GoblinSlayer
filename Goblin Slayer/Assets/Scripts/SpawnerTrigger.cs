using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class SpawnerTrigger : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.name == "Player")
        {
            // SpawnerTrigger is always a children of Spawner, therefore,
            // a Spawner instance must be available in parent.
            var spawner = GetComponentInParent<Spawner>();
            if (spawner) spawner.Spawn();

            // Once this trigger has been activated, it has no use, destroy
            // the GameObject and all its components to free memory.
            Destroy(gameObject);
        }
    }

}
