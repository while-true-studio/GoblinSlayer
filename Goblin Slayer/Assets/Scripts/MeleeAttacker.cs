using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttacker : MonoBehaviour
{
    /// <summary>
    /// The melee attack range for this component.
    /// </summary>
    public float range = 3;

    // Use this for initialization
	void Start()
    {
    }
	
	// Update is called once per frame
	void Update()
    {
        // TODO: Remove this before merging
        FindObjects(Vector2.right);
    }

    /// <summary>
    /// Find all colliders between the game object that has this component and the
    /// vector it is aiming to inside a range.
    /// </summary>
    /// <param name="normalVector">The normal vector the game object is aiming to.</param>
    /// <returns>An array of RaycastHit2D</returns>
    RaycastHit2D[] FindObjects(Vector2 normalVector)
    {
        Vector2 fromPosition = transform.position;
        Vector2 toPosition = normalVector * range;
        RaycastHit2D[] raycastHits = Physics2D.RaycastAll(fromPosition, toPosition, range);

        // TODO: Remove the following two lines before merging.
        // Checks for more than one hits, since the player itself is always included
        bool hit = raycastHits.Length > 1;
        Debug.DrawRay(fromPosition, toPosition, hit ? Color.green : Color.red);
        return raycastHits;
    }

}
