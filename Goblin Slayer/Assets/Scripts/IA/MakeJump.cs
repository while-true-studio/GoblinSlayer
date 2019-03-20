using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class MakeJump : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Follower_AI follower = collision.GetComponent<Follower_AI>();
        //TODO: This problably needs a revision to make sure the jumping works
        if (follower)
            follower.MakeMeJump();
        
    }
}
