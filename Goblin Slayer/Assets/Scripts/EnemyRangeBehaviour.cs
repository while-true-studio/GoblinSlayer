using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeBehaviour : MonoBehaviour
{
    public float AttackRange = 3.0f;
    public float AttackDelay = 1.0f;
    public GameObject Player;
    private int layerMask = 0;

    private void Start()
    {
        layerMask = LayerMask.GetMask("Player", "Blocks");
        StartCoroutine(OnRange());
    }

    /// <summary>
    /// Coroutine method that checks if the player is in range, delaying
    /// the loop by a second when it attacks it.
    /// </summary>
    /// <returns>The IEnumerator for the coroutine.</returns>
    private IEnumerator OnRange()
    {
        while (true)
        {
            if (CanAttackPlayer())
            {
                Player.GetComponent<Attackable>().OnAttack(5);
                Debug.Log(Player.GetComponent<Health>().health);
                yield return new WaitForSeconds(AttackDelay);
            } 
            else
            {
                yield return null;
            }
        }
    }

    /// <summary>
    /// Checks if the enemy can attack the player, considering both range and
    /// visibility.
    /// </summary>
    /// <returns>A value specifying whether or not the enemy can attack the player.</returns>
    private bool CanAttackPlayer()
    {
        if (!HasPlayerInRange()) return false;

        Vector2 fromPosition = transform.position;
        Vector2 toPosition = Player.transform.position;
        RaycastHit2D hit = Physics2D.Linecast(fromPosition, toPosition, layerMask);
        return hit.collider ? hit.rigidbody.tag == "Player" : false;
    }

    /// <summary>
    /// Checks if the player is in attack range of the player.
    /// </summary>
    /// <returns>A value specifying whether or not the player is in range of this enemy.</returns>
    private bool HasPlayerInRange()
    {
        float distance = Mathf.Abs((transform.position - Player.transform.position).magnitude);
        return distance <= AttackRange;
    }

}
