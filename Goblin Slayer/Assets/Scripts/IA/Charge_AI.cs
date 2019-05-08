using UnityEngine;

[RequireComponent(typeof(RangeObserver_AI))]
[RequireComponent(typeof(Follower_AI))]
[RequireComponent(typeof(Charge))]
[RequireComponent(typeof(Target_AI))]
public class Charge_AI : Brain_AI
{
    private RangeObserver_AI rangeObserverAi;
    private Follower_AI followerAi;
    private Charge charge;
    private Target_AI targetAi;

    private void Start()
    {
        rangeObserverAi = GetComponent<RangeObserver_AI>();
        followerAi = GetComponent<Follower_AI>();
        charge = GetComponent<Charge>();
        targetAi = GetComponent<Target_AI>();
    }

    protected override void RegisterCallbacks()
    {
        rangeObserverAi.AddInRangeCallback(OnRange);
        rangeObserverAi.AddTooFarCallback(OnTooFar);
    }

    protected override void UnRegisterCallbacks()
    {
        rangeObserverAi.RemoveInRangeCallback(OnRange);
        rangeObserverAi.RemoveTooFarCallback(OnTooFar);
    }

    private void OnRange()
    {
        followerAi.StopFollowing();
        charge.ChargeAt(targetAi.GetTarget());
    }

    private void OnTooFar()
    {
        followerAi.Follow();
    }
}