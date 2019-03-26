using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AutoJumper_AI))]
public class JumpToTarget_AI : MonoBehaviour {

    AutoJumper_AI autoJumper;
    private void Start()
    {
        autoJumper = GetComponent<AutoJumper_AI>();
    }

    public void OnRange()
    {
        autoJumper.MakeJump();
    }
}
