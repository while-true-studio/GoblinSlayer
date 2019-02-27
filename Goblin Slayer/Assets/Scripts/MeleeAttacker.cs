using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttacker : MonoBehaviour
{
    public float range = 3;

    // Use this for initialization
	void Start()
    {
    }
	
	// Update is called once per frame
	void Update()
    {
        FindObject();
    }

    RaycastHit2D[] FindObject()
    {
        Vector2 fromPosition = transform.position;
        Vector2 toPosition = Vector2.right * range;
        RaycastHit2D[] raycastHits = Physics2D.RaycastAll(fromPosition, toPosition, range);
        // Checks for more than one hits, since the player itself is always included
        bool hit = raycastHits.Length > 1;

        Debug.DrawRay(fromPosition, toPosition, hit ? Color.green : Color.red);
        return hit ? raycastHits : null;
    }

}
