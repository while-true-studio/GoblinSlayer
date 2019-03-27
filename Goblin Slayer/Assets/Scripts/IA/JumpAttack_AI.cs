using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RangeObserver_AI))]
[RequireComponent(typeof(AutoJumper_AI))]
[RequireComponent(typeof(Follower_AI))]
[RequireComponent(typeof(MeleeAttacker_AI))]
public class JumpAttack_AI : MonoBehaviour {

    public Transform target;

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


        RegisterCallbacks();
    }
     private void OnDestroy()
     {
        UnRegisterCallbacks();
     }
    private void RegisterCallbacks()
    {
        rangeObserver.AddTooFarCallback(OnTooFar);
        rangeObserver.AddTooCloseCallback(OnTooClose);
        rangeObserver.AddInRangeCallback(OnRange);
    }
    private void UnRegisterCallbacks()
    {
        rangeObserver.RemoveTooFarCallback(OnTooFar);
        rangeObserver.RemoveTooCloseCallback(OnTooClose);
        rangeObserver.RemoveInRangeCallback(OnRange);
    }

   
    public void OnTooClose() { attacker.Attack(target); }
    public void OnTooFar() { follower.Follow(); }
    public void OnRange()  { autoJumper.MakeJump(); }
}
