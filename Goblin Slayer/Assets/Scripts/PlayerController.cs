using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Walker))]
[RequireComponent(typeof(Jumper))]
public class PlayerController : MonoBehaviour {

    Walker walker;
    Jumper jumper;

    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode jumpKey;

    private KeyCode lastDirectionKeyPressed;

	// Use this for initialization
	void Start () {
        walker = GetComponent<Walker>();
        jumper = GetComponent<Jumper>();
	}
	
	// Update is called once per frame
	void Update () {

        //Walk to the left
        if (Input.GetKey(leftKey))
        {
            lastDirectionKeyPressed = leftKey;
            walker.Walk(Walker.WalkDirection.LEFT);
        }
        //Walk to the right
        else if (Input.GetKey(rightKey))
        {
            lastDirectionKeyPressed = rightKey;
            walker.Walk(Walker.WalkDirection.RIGHT);
        }
        //Stop walking
        if ((Input.GetKeyUp(leftKey)  && lastDirectionKeyPressed == leftKey)
          ||(Input.GetKeyUp(rightKey) && lastDirectionKeyPressed == rightKey))
            walker.Stop();
        
        //Jump
        if (Input.GetKeyDown(jumpKey))
            jumper.Jump();

	}
}
