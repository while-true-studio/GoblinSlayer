using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Walker))]
public class PlayerController : MonoBehaviour
{
    Walker walker;
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode jumpKey;
    public KeyCode switchModeKey;
    public KeyCode attackKey;
    public KeyCode defendKey;
    public KeyCode menuKey;

    private KeyCode lastDirectionKeyPressed;
    private PlayerAttackManager playerAttackManager;
    private PauseBehaviour pauseHUD;
    private Animator animator;
    public bool defending = false;


	void Start () {
        walker = GetComponent<Walker>();
        playerAttackManager = GetComponent<PlayerAttackManager>();
        pauseHUD = GameObject.Find("HUD").GetComponent<PauseBehaviour>();
    }

	// Update is called once per frame
	void Update () {
        if (!defending)
        {
            //Walk to the left
            if (Input.GetKey(leftKey))
            {
                lastDirectionKeyPressed = leftKey;
                walker.Walk(Walker.Direction.LEFT);
            }
            //Walk to the right
            else if (Input.GetKey(rightKey))
            {
                lastDirectionKeyPressed = rightKey;
                walker.Walk(Walker.Direction.RIGHT);
            }
            //Stop walking
            if ((Input.GetKeyUp(leftKey) && lastDirectionKeyPressed == leftKey)
              || (Input.GetKeyUp(rightKey) && lastDirectionKeyPressed == rightKey))
                walker.Stop();

            //Jump
            if (Input.GetKeyDown(jumpKey))
                playerAttackManager.JumpController();

            if (Input.GetKeyDown(switchModeKey))
            {
                playerAttackManager.SwitchMode();
            }

            if (Input.GetKeyDown(attackKey))
            {
               
                playerAttackManager.Attack();
            }
        }

        if(Input.GetKey(defendKey))
        {
            defending = true;
            playerAttackManager.Defend();
        }
       else
        {
            defending = false;
            playerAttackManager.StopDefending();
        }

        if(Input.GetKeyDown(menuKey))
        {
            pauseHUD.ActivePause();
        }
    }

}
