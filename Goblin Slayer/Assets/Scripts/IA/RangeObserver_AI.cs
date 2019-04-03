using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RangeObserver_AI : MonoBehaviour {
    //TODO coment this stuff up
    public bool noMaxRange;
    public float maxRange;

    public bool noMinRange;
    public float minRange;

    public Transform target;
    
    private List<Action> tooFarCallbacks    = new List<Action>();
    private List<Action> tooCloseCallbacks  = new List<Action>();
    private List<Action> inRangeCallbacks   = new List<Action>();



    public void AddTooFarCallback(Action callback) { tooFarCallbacks.Add(callback);}
    public void AddTooCloseCallback(Action callback) { tooCloseCallbacks.Add(callback); }
    public void AddInRangeCallback(Action callback) { inRangeCallbacks.Add(callback); }

    public void RemoveTooFarCallback(Action callback) { tooFarCallbacks.Remove(callback); }
    public void RemoveTooCloseCallback(Action callback) { tooCloseCallbacks.Remove(callback); }
    public void RemoveInRangeCallback(Action callback) { inRangeCallbacks.Remove(callback); }

    private void CallCallbacks(List<Action> list) { foreach(Action callback in list) callback(); }

    private void Update()
    {
        float distance = Vector2.Distance(transform.position, target.position);

        //Debug.Log(string.Format("Distance: {0}    Max: {1}    Min:{2}", distance, maxRange, minRange));

        if (distance > maxRange)
        {
            CallCallbacks(tooFarCallbacks);
            if (maxRange == float.NegativeInfinity) { CallCallbacks(inRangeCallbacks); }
        }
        else if (distance < minRange)
        {
            CallCallbacks(tooCloseCallbacks);
            if (minRange == float.PositiveInfinity) { CallCallbacks(inRangeCallbacks); }
        }
        else
            CallCallbacks(inRangeCallbacks);

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
