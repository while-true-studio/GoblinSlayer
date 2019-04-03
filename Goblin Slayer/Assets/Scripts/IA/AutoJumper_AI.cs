using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Jumper))]

public class AutoJumper_AI : MonoBehaviour {

    private Jumper jumper;
	void Start () {
        jumper = GetComponent<Jumper>();

    }

    /// <summary>
    /// Makes this agent jump
    /// </summary>
    public void MakeJump()
    {
        jumper.Jump();
    }

}
