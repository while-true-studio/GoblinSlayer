using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RangeObserver_AI))]
[RequireComponent(typeof(Shooter_AI))]
[RequireComponent(typeof(Follower_AI))]
[RequireComponent(typeof(KeepDistanceWith))]
[RequireComponent(typeof(Target_AI))]
public class ShootAndKeepDistance : Brain_AI {

    private Target_AI target;
    private RangeObserver_AI rangeObserver;
    private Shooter_AI shooter;
    private Follower_AI follower;
    private KeepDistanceWith keepDistance;

    void Start () {
        rangeObserver = GetComponent<RangeObserver_AI>();
        shooter = GetComponent<Shooter_AI>();
        follower = GetComponent<Follower_AI>();
        keepDistance = GetComponent<KeepDistanceWith>();
        target = GetComponent<Target_AI>();

        /*Config*/
        keepDistance.distance = rangeObserver.minRange;

        RegisterCallbacks();
	}
    protected override void RegisterCallbacks()
    {
        rangeObserver.AddTooFarCallback(OnTooFar);
        rangeObserver.AddInRangeCallback(OnInRange);
        rangeObserver.AddTooCloseCallback(OnTooClose);
    }

    protected override void UnRegisterCallbacks()
    {
        rangeObserver.RemoveTooFarCallback(OnTooFar);
        rangeObserver.RemoveInRangeCallback(OnInRange);
        rangeObserver.RemoveTooCloseCallback(OnTooClose);
    }


    public void OnTooFar()
    {
        follower.Follow();
    }
    public void OnTooClose()
    {
        keepDistance.KeepDistance(target.GetTarget());
    }
    public void OnInRange()
    {
        follower.StopFollowing();
        shooter.Attack(target.GetTarget());
    }
}
