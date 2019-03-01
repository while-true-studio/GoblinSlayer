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
        MakeAttack(Vector2.right);
    }

    /// <summary>
    /// Make an attack on all game objects between the game object that has this component
    /// and the vector it is aiming to inside a range that has no obstacle between both.
    /// </summary>
    /// <param name="normalVector">The normal vector the game object is aiming to.</param>
    public void MakeAttack(Vector2 normalVector)
    {
        var gameObjects = FindGameObjects(normalVector);

#if UNITY_EDITOR
        bool hit = gameObjects.Count > 0;
        Debug.DrawRay(transform.position, normalVector * range, hit ? Color.green : Color.red);
#endif
    }

    /// <summary>
    /// Find all game objects between the game object that has this component and the vector
    /// it is aiming to inside a range, filtering the game object itself and all the objects
    /// between the first wall (if found) until the end.
    /// </summary>
    /// <param name="normalVector">The normal vector the game object is aiming to.</param>
    /// <returns>An array of GameObject.</returns>
    /// <!-- TODO: Change GameObject to Attackable -->
    public List<GameObject> FindGameObjects(Vector2 normalVector)
    {
        // Get all raycast hits between the game object and the target vector (normal vector * range).
        RaycastHit2D[] raycastHits = FindRaycastHits(normalVector);
        List<GameObject> gameObjects = new List<GameObject>();

        for (int i = 1; i < raycastHits.Length; i++)
        {
            var raycastHit = raycastHits[i];
            if (raycastHit.collider.tag == "Wall") break;
            if (raycastHit.collider.gameObject) gameObjects.Add(raycastHit.collider.gameObject);
        }

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
        return Physics2D.RaycastAll(fromPosition, toPosition, range);
    }

}
