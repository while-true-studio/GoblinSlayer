using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(Walker))]
[RequireComponent(typeof(Jumper))]
public class Follower_AI : MonoBehaviour {

    // The object to follow
    public Transform target;
   
    // Distance at wich IA stops and is considered that doesn'tneed to go any closer to the target
    public float minDistance;
    /// <summary>
    /// Callback. Will be called once reached <seealso cref="minDistance"/>
    /// </summary>
    public UnityEvent onGoalReached;

    private Walker walker;
    private Jumper jumper;

    private void Start()
    {
        walker = GetComponent<Walker>();
        jumper = GetComponent<Jumper>();
    }

    private void Update()
    {
        Vector2 dist = target.position - transform.position;

        //While haven't reached the minDistance update the walking direction
        if (dist.magnitude > minDistance)
            walker.Walk(dist.x > 0 ? Walker.WalkDirection.RIGHT : Walker.WalkDirection.LEFT);

        else//We have reached our goal
        {
            walker.Stop();
            onGoalReached.Invoke();
        }

    }

    /// <summary>
    /// Makes this agent jump
    /// </summary>
    public void MakeMeJump() { jumper.Jump(); }
}
