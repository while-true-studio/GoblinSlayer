using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class SpawnerTrigger : MonoBehaviour {

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
        Gizmos.DrawLine(transform.position, transform.parent.position);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.parent.position, transform.parent.localScale);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.name == "Player")
        {
            // SpawnerTrigger is always a children of Spawner, therefore,
            // a Spawner instance must be available in parent.
            var spawner = GetComponentInParent<Spawner>();
            if (spawner) spawner.Spawn();

            // Once this trigger has been activated, it has no use, set active
            // to false to prevent further CPU usage.
            gameObject.SetActive(false);
        }
    }

}
