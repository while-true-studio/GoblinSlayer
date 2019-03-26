using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RangeObserver_AI : MonoBehaviour {

    public bool noMaxRange;
    public float maxRange;

    public bool noMinRange;
    public float minRange;

    public Transform target;

    public UnityEvent onTooFar;
    public UnityEvent onInRange;
    public UnityEvent onTooClose;

    private void Update()
    {
        float distance = Vector2.Distance(transform.position, target.position);

        if (!noMaxRange && distance > maxRange)
            onTooFar.Invoke();
        else if (!noMinRange && distance < minRange)
            onTooClose.Invoke();
        else onInRange.Invoke();
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, maxRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, minRange);


    }
}
