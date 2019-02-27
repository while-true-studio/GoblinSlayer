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
        MakeAttack(new Vector2(1.0f, 1.0f));
    }

    /// <summary>
    /// Make an attack on all game objects between the game object that has this component
    /// and the vector it is aiming to inside a range that has no obstacle between both.
    /// </summary>
    /// <param name="normalVector">The normal vector the game object is aiming to.</param>
    public void MakeAttack(Vector2 normalVector)
    {
        GameObject[] gameObjects = FindGameObjects(normalVector);
        // TODO: Filter gameobjects by its component "Attackable", when
        // it becomes available.
    }

    /// <summary>
    /// Find all game objects between the game object that has this component and the vector
    /// it is aiming to inside a range, filtering the game object itself and all the objects
    /// between the first wall (if found) until the end.
    /// </summary>
    /// <param name="normalVector">The normal vector the game object is aiming to.</param>
    /// <returns>An array of GameObject.</returns>
    public GameObject[] FindGameObjects(Vector2 normalVector)
    {
        // Get all raycast hits between the game object and the target vector (normal vector * range).
        RaycastHit2D[] raycastHits = FindRaycastHits(normalVector);
        
        // Filter all raycast hits until it finds a wall.
        int max = 0;
        while (max < raycastHits.Length && raycastHits[max].collider.tag != "Wall") max++;

        // Make an array of GameObjects mapping the raycast hits array.
        GameObject[] gameObjects = new GameObject[max];
        for (int i = 1; i < max; i++) gameObjects[i - 1] = raycastHits[i].collider.gameObject;
        return gameObjects;
    }

    /// <summary>
    /// Find all colliders between the game object that has this component and the
    /// vector it is aiming to inside a range.
    /// </summary>
    /// <param name="normalVector">The normal vector the game object is aiming to.</param>
    /// <returns>An array of RaycastHit2D.</returns>
    public RaycastHit2D[] FindRaycastHits(Vector2 normalVector)
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
