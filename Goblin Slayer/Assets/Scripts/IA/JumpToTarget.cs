using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Follower_AI))]
public class JumpToTarget : MonoBehaviour {

    Follower_AI follower;
    private void Start()
    {
        follower = GetComponent<Follower_AI>();
    }

    public void OnRange()
    {
        follower.MakeMeJump();
    }
}
