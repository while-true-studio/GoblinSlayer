using UnityEngine;

[RequireComponent(typeof(RangeObserver_AI))]
[RequireComponent(typeof(Charge))]
[RequireComponent(typeof(Target_AI))]
public class Charge_AI : Brain_AI
{
    private RangeObserver_AI rangeObserverAi;
    private Charge charge;
    private Target_AI targetAi;

    private void Start()
    {
        rangeObserverAi = GetComponent<RangeObserver_AI>();
        charge = GetComponent<Charge>();
        targetAi = GetComponent<Target_AI>();
        RegisterCallbacks();
    }

    protected override void RegisterCallbacks()
    {
        rangeObserverAi.AddTooFarCallback(OnTooFar);
    }

    protected override void UnRegisterCallbacks()
    {
        rangeObserverAi.RemoveTooFarCallback(OnTooFar);
    }

    private void OnTooFar()
    {
        charge.ChargeAt(targetAi.GetTarget());
    }
}