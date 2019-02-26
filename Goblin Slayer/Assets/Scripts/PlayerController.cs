#define JOYSTICK_SUPPORTED

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Walker))]
[RequireComponent(typeof(Jumper))]
public class PlayerController : MonoBehaviour {

    private Walker walker;
    private Jumper jumper;
#if !JOYSTICK_SUPPORTED
    public KeyCode leftKey; //Left  movement key
    public KeyCode rightKey;//Right movement key
    public KeyCode jumpKey; //Jump key
    //The last key wich represents a direction pressed
    private KeyCode lastDirectionKeyPressed;
#endif
    //Get dependences
	private void Start () {
        walker = GetComponent<Walker>();
        jumper = GetComponent<Jumper>();
	}

    //Get the input and manage it
    private void Update ()
    {
#if JOYSTICK_SUPPORTED
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal == 0)//Shoud we take joystick's dead zone into a count?
            walker.Stop();
        else
            walker.Walk(horizontal > 0 ? Walker.WalkDirection.RIGHT : Walker.WalkDirection.LEFT);

        if (Input.GetButton("Jump"))
            jumper.Jump();
#else
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
#endif
	}
}
