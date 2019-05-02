using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class SpawnerTrigger : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        var tf = transform;
        var parent = tf.parent;
        var position = tf.position;
        var parentPosition = parent.position;

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(position, tf.localScale);

        Gizmos.DrawLine(position, parentPosition);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(parentPosition, parent.localScale);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player") || collision.name != "Player") return;

        // SpawnerTrigger is always a children of Spawner, therefore,
        // a Spawner instance must be available in parent.
        var spawner = GetComponentInParent<Spawner>();
        if (spawner) spawner.Spawn();

        // Once this trigger has been activated, it has no use, set active
        // to false to prevent further CPU usage.
        gameObject.SetActive(false);
    }
}