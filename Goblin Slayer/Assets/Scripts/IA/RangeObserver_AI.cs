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

        //Debug.Log(string.Format("Distance: {0}    Max: {1}    Min:{2}", distance, maxRange, minRange));

        if (distance > maxRange)
        {
            onTooFar.Invoke();
            if (maxRange == float.NegativeInfinity) { goto no_limit; }
            return;
        }
        else if (distance < minRange)
        {
            onTooClose.Invoke();
            if (minRange == float.PositiveInfinity) { goto no_limit; }
            return;
        }
        else
            goto no_limit;

        no_limit:
            onInRange.Invoke();

    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, maxRange);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, minRange);

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, target.position);


    }
}
