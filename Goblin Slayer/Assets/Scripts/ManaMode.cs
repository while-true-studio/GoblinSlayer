using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaMode : MonoBehaviour
{
    public ManaState ModeState;
    private PlayerAttackManager pl;
    public enum ManaState { Normal, Battle, Critic }
    private Mana mn;
    private Health health;
    public float autoManaNormal;
    public float autoManaBattle;
    public float autoManaCritic;
    public float IncrementoModoGuerrero;
    void Start()
    {
        pl = GetComponent<PlayerAttackManager>();
        mn = GetComponent<Mana>();
        health = GetComponent<Health>();
    }

    public void ChangueRegenMana()
    {
        switch (ModeState)
        {
            case ManaState.Normal:
                mn.autoManaRegenRate = autoManaNormal;
                if (health.GetHP() < health.maxHealth * 3.0f / 4.0f)

                { ModeState = ManaState.Battle; }
                break;
            case ManaState.Battle:
                mn.autoManaRegenRate = autoManaBattle;

                if (health.GetHP() < health.maxHealth * 1.0f / 4.0f)
                {
                    ModeState = ManaState.Critic;
                }
                else if (health.GetHP() >= health.maxHealth * 3.0f / 4.0f) ModeState = ManaState.Normal;
                break;
            case ManaState.Critic:
                mn.autoManaRegenRate = autoManaCritic;
                if (health.GetHP() > health.maxHealth * 1 / 4)
                {

                    ModeState = ManaState.Battle;
                }
                break;
        }
        if (pl.GetMode() == 0)
        {
            mn.autoManaRegenRate *= IncrementoModoGuerrero;
        }
    }
}



