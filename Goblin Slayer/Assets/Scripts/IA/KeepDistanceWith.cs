using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Walker))]
public class KeepDistanceWith : MonoBehaviour {

    public float distance;
    private Walker walker;

    private void Start()
    {
        walker = GetComponent<Walker>();
    }

    public void KeepDistance(Transform target)
    {
        Vector2 v = target.position - transform.position;

        if(v.magnitude < distance)
            walker.Walk((v.normalized.x > 0)? Walker.Direction.LEFT : Walker.Direction.RIGHT);
    }



}
