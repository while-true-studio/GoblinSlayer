using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Walker : MonoBehaviour {

    //Velocity in wich the gameObejct moves in the X-axis
    public float velocity;


    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    //The state of the walker
    //    Note: 
    //    - STOP  : The gameObject is not moving in the X-axis.
    //    - RIGHT : The gameObject is walking towards the positive X-axis.
    //    - LEFT  : The gameObject is walking towards the negative X-axis.
    public enum WalkingState { STOP = 0, RIGHT = 1, LEFT = -1};


    //The walking direction
    //  Note: it's guaranteed that: 
    //      WalkingState.RIGHT == WalkingDirection.RIGHT 
    // and   WalkingState.LEFT == WalkingDirection.LEFT
    public enum WalkDirection { RIGHT = WalkingState.RIGHT, LEFT = WalkingState.LEFT};
    public WalkingState CurrentWalkingState { get; private set; }

    /// <summary>
    /// Makes the gameObject move in the given direction
    /// </summary>
    /// <param name="state">The direction in wich the gameObject should move</param>
    public void Walk(WalkDirection direction)
    {
        CurrentWalkingState = (WalkingState)direction;
        rb.velocity = new Vector2((float)direction * velocity, rb.velocity.y);
    }
    /// <summary>
    /// Makes the gameObject stop in the X-axis
    /// </summary>
    public void Stop()
    {
        CurrentWalkingState = WalkingState.STOP;
        rb.velocity = new Vector2(0, rb.velocity.y);
    }
}