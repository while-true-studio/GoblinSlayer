using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Walker))]
public class EnemyMovement : MonoBehaviour
{
    public Transform PlayerTransform;
    private Walker walker;

    private void Start()
    {
        walker = GetComponent<Walker>();
    }

    private void Update()
    {
        float playerX = PlayerTransform.position.x;
        float startX = transform.position.x;

        // Player .. Enemy
        if (playerX < startX)
            walker.Walk(Walker.Direction.LEFT);
        // Enemy .. Player
        else if (playerX > startX)
            walker.Walk(Walker.Direction.RIGHT);
    }

}
