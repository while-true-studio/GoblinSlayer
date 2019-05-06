using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaMode : MonoBehaviour
{
    public ManaState ModeState;


    private Mana mn;
    private Health health;
    public float autoManaNormal;
    public float autoManaBattle;
    public float autoManaCritic;

    void Start()
    {
        mn = GetComponent<Mana>();
        health = GetComponent<Health>();
    }
    void Update()
    {
        switch (ModeState)
        {
            case ManaState.Normal:
                mn.autoManaRegenRate = autoManaNormal;
                if (health.GetHP() < health.maxHealth * 3 / 4)

                { ModeState = ManaState.Battle; }


                break;
            case ManaState.Battle:
                mn.autoManaRegenRate = autoManaBattle;

                if (health.GetHP() < health.maxHealth * 1 / 4)
                {
                    ModeState = ManaState.Critic;
                }
                else if (health.GetHP() >= health.maxHealth * 3 / 4) ModeState = ManaState.Normal;

                break;
            case ManaState.Critic:
                mn.autoManaRegenRate = autoManaCritic;
                if (health.GetHP() > health.maxHealth * 1 / 4)
                {

                    ModeState = ManaState.Battle;
                }

                break;
        }
    }

    public enum ManaState
    {
        Normal,
        Battle,
        Critic
    }
}
