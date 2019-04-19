using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public KeyCode next, back, Enter;
    public LevelController levelController;
    private bool moving = false;

    private void Start()
    {
        levelController.GetComponent<LevelController>();
    }

    void Update ()
    {
        if(!moving && Input.GetKeyDown(Enter))
        {
            levelController.SelectLevel();
        }
		if(!moving && Input.GetKeyDown(back))
        {
            levelController.MakeMovement(LevelController.MOVEMENT.BACK);
        }
        if (!moving && Input.GetKeyDown(next))
        {
            levelController.MakeMovement(LevelController.MOVEMENT.FORWARD);
        }
    }

    public void InputStatus(bool status)
    {
        moving = status;
    }
}
