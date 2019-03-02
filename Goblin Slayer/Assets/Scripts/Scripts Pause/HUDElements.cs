using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDElements : MonoBehaviour {
    //Script for positioning HUD elements in the visual screen 
    //or in another position to not watch them.

    Timer stateTimer;
    RectTransform positionHUDScreen, positionCanvas;  

    void Start()
    {
        positionHUDScreen = GetComponent<RectTransform>();
        positionCanvas = GameObject.Find("Canvas").GetComponent<RectTransform>();
        stateTimer = GameObject.Find("Timer").GetComponent<Timer>();
    }

    void Update()
    {
        if (stateTimer.pause)
        {
            positionHUDScreen.position = new Vector3(positionCanvas.position.x + 1000, positionCanvas.position.y + 1000);
        }
        else
            positionHUDScreen.position = positionCanvas.position;
    }
}
