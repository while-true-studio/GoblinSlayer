using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttacker : MonoBehaviour
{
    private Animator animator;
    /// <summary>
    /// The melee attack range for this component.
    /// </summary>
    public float range = 3;
    public int damage = 10;
    public float cooldownTime = 0.8f;
    private Cooldown cooldown;

    private void Start()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
        cooldown = new Cooldown(cooldownTime);
    }

    /// <summary>
    /// Make an attack on all game objects between the game object that has this component
    /// and the vector it is aiming to inside a range that has no obstacle between both.
    /// </summary>
    /// <param name="normalVector">The normal vector the game object is aiming to.</param>
    public void MakeAttack(Vector2 normalVector)
    {
        if (!cooldown.CanUse()) return;
        AttackAnimator();
        var targets = FindGameObjects(normalVector);
        foreach(var target in targets )
        {
            target.OnAttack(damage);
        }
//if UNITY_EDITOR
        bool hit = targets.Count > 0;
        Debug.DrawRay(transform.position, normalVector * range, hit ? Color.green : Color.red);
//#endif
    }

    /// <summary>
    /// Find all game objects between the game object that has this component and the vector
    /// it is aiming to inside a range, filtering the game object itself and all the objects
    /// between the first wall (if found) until the end.
    /// </summary>
    /// <param name="normalVector">The normal vector the game object is aiming to.</param>
    /// <returns>An array of GameObject.</returns>
    /// <!-- TODO: Change GameObject to Attackable -->
    private List<Attackable> FindGameObjects(Vector2 normalVector)
    {
        // Get all raycast hits between the game object and the target vector (normal vector * range).
        RaycastHit2D[] raycastHits = FindRaycastHits(normalVector);
        List<Attackable> gameObjects = new List<Attackable>();

        for (int i = 1; i < raycastHits.Length; i++)
        {
            var raycastHit = raycastHits[i];
            if (raycastHit.collider.tag == "Wall") break;
            var attackable = raycastHit.collider.GetComponent<Attackable>();
            if (attackable != null) gameObjects.Add(attackable);
        }

        return gameObjects;
    }

    /// <summary>
    /// Find all colliders between the game object that has this component and the
    /// vector it is aiming to inside a range.
    /// </summary>
    /// <param name="normalVector">The normal vector the game object is aiming to.</param>
    /// <returns>An array of RaycastHit2D.</returns>
    private RaycastHit2D[] FindRaycastHits(Vector2 normalVector)
    {
        Vector2 fromPosition = transform.position;
        Vector2 toPosition = normalVector;
        return Physics2D.RaycastAll(fromPosition, toPosition, range);
    }

    private void AttackAnimator()
    {
        animator.SetTrigger("Attack");
    }
}
