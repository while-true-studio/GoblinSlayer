using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RangeObserver_AI))]
[RequireComponent(typeof(AutoJumper_AI))]
[RequireComponent(typeof(Follower_AI))]
[RequireComponent(typeof(MeleeAttacker_AI))]
[RequireComponent(typeof(Target_AI))]
public class JumpAttack_AI : Brain_AI {

    private Target_AI target;

    //Observer
    private RangeObserver_AI rangeObserver;
    //Actors
    private AutoJumper_AI       autoJumper;
    private Follower_AI         follower;
    private MeleeAttacker_AI    attacker;

    private void Start()
    {
        autoJumper      = GetComponent<AutoJumper_AI>();
        rangeObserver   = GetComponent<RangeObserver_AI>();
        follower        = GetComponent<Follower_AI>();
        attacker        = GetComponent<MeleeAttacker_AI>();
        target          = GetComponent<Target_AI>();

        RegisterCallbacks();
    }
     private void OnDestroy()
     {
        UnRegisterCallbacks();
     }
    protected override void RegisterCallbacks() 
    {
        rangeObserver.AddTooFarCallback(OnTooFar);
        rangeObserver.AddTooCloseCallback(OnTooClose);
        rangeObserver.AddInRangeCallback(OnRange);
    }
    protected override void UnRegisterCallbacks()
    {
        rangeObserver.RemoveTooFarCallback(OnTooFar);
        rangeObserver.RemoveTooCloseCallback(OnTooClose);
        rangeObserver.RemoveInRangeCallback(OnRange);
    }

   
    public void OnTooClose(){attacker.Attack(target.GetTarget());}
    public void OnTooFar() { follower.Follow(); }
    public void OnRange()  { autoJumper.MakeJump(); }
}
