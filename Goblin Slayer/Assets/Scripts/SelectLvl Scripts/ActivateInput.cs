using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateInput : MonoBehaviour
{
    private InputController inputController;

    private void Start()
    {
        GameObject go = GameObject.Find("LvlSelecter");
        inputController = go.GetComponent<InputController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("ENTER");
        inputController.InputStatus(false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        print("OUT");

        inputController.InputStatus(true);
    }
}
