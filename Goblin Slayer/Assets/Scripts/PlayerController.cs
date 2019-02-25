using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Walker))]
[RequireComponent(typeof(Jumper))]
public class PlayerController : MonoBehaviour {

    private Walker walker;
    private Jumper jumper;

    public KeyCode leftKey; //Left  movement key
    public KeyCode rightKey;//Right movement key
    public KeyCode jumpKey; //Jump key

    //The last key wich represents a direction pressed
    private KeyCode lastDirectionKeyPressed;

    //Get dependences
	private void Start () {
        walker = GetComponent<Walker>();
        jumper = GetComponent<Jumper>();
	}

    //Get the input and manage it
    private void Update ()
    {

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
