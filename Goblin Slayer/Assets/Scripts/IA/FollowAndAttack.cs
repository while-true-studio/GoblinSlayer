using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RangeObserver_AI))]
[RequireComponent(typeof(Follower_AI))]
[RequireComponent(typeof(MeleeAttacker_AI))]
[RequireComponent(typeof(Target_AI))]
public class FollowAndAttack : Brain_AI
{
    RangeObserver_AI rangeObserver;
    Follower_AI follower;
    MeleeAttacker_AI meleeAttaker;
    Target_AI target;
    private void Start()
    {
        rangeObserver = GetComponent<RangeObserver_AI>();
        follower = GetComponent<Follower_AI>();
        meleeAttaker = GetComponent<MeleeAttacker_AI>();
        target = GetComponent<Target_AI>();

        RegisterCallbacks();
    }

    protected override void RegisterCallbacks()
    {
        rangeObserver.AddInRangeCallback(OnRange);
        rangeObserver.AddTooFarCallback(OnTooFar);
        
    }

    protected override void UnRegisterCallbacks()
    {
        rangeObserver.RemoveInRangeCallback(OnRange);
        rangeObserver.RemoveTooFarCallback(OnTooFar);

    }
    public void OnRange()
    {
        follower.StopFollowing();
        meleeAttaker.Attack(target.GetTarget());
    }
    public void OnTooFar() { follower.Follow(); }

}
