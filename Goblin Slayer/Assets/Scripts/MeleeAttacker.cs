using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttacker : MonoBehaviour
{
    private Animator animator;
    private Animator effects;

    /// <summary>
    /// The melee attack range for this component.
    /// </summary>
    public float range = 3;

    public int damage = 10;
    public float cooldownTime = 0.8f;
    private Cooldown cooldown;
    private AttackSounds sounds;

    private void Start()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
        effects = transform.GetChild(1).GetComponent<Animator>();
        cooldown = new Cooldown(cooldownTime);
        sounds = GetComponentInChildren<AttackSounds>();
    }

    /// <summary>
    /// Make an attack on all game objects between the game object that has this component
    /// and the vector it is aiming to inside a range that has no obstacle between both.
    /// </summary>
    /// <param name="normalVector">The normal vector the game object is aiming to.</param>
    public void MakeAttack(Vector2 normalVector)
    {
        if (!cooldown.CanUse()) return;
        //if (!sounds.IsSoundActive()) { sounds.PlayEffect(sounds.meleeAttack); }
        sounds.PlayEffect(sounds.meleeAttack);
        AttackAnimator();
        var targets = FindGameObjects(normalVector);
        foreach (var target in targets)
        {
            target.OnAttack(damage);
        }

//if UNITY_EDITOR
        var hit = targets.Count > 0;
        Debug.DrawRay(transform.position, normalVector * range, hit ? Color.green : Color.red);
//#endif
    }

    /// <summary>
    /// Find all game objects between the game object that has this component and the vector
    /// it is aiming to inside a range, filtering the game object itself and all the objects
    /// between the first wall or the shield (if found) until the end.
    /// </summary>
    /// <param name="normalVector">The normal vector the game object is aiming to.</param>
    /// <returns>An array of GameObject.</returns>
    private List<Attackable> FindGameObjects(Vector2 normalVector)
    {
        // Get all raycast hits between the game object and the target vector (normal vector * range).
        var raycastHits = FindRaycastHits(normalVector);
        var gameObjects = new List<Attackable>();

        foreach (var raycastHit in raycastHits)
        {
            if (raycastHit.collider.CompareTag("Blocks") || raycastHit.collider.CompareTag("Shield")) break;
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
        Vector2 fromPosition = transform.position, toPosition = normalVector;
        return Physics2D.RaycastAll(fromPosition, toPosition, range, ~(1 << LayerMask.NameToLayer(tag)));
    }

    private void AttackAnimator()
    {
        if (CompareTag("Player"))
            effects.SetTrigger("Attack");

        animator.SetTrigger("Attack");

    }
}