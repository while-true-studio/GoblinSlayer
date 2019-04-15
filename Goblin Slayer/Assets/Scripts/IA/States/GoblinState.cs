using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinState : MonoBehaviour
{
    public enum STATE { DEAD = 0, REPOSE = 1, ATTACKING = 2 }
    private STATE currState = STATE.REPOSE;

    public void AttackingMode(bool state)
    {
        if (state) { currState = STATE.ATTACKING; }
        else { currState = STATE.REPOSE; }
    }

    public void GoblinIsDead()
    {
        currState = STATE.DEAD;
    }

    public int InWhatState()
    {
        return (int)currState;
    }
}
