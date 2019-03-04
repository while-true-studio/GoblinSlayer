using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDElements : MonoBehaviour {
    //Script for positioning HUD elements in the visual screen 
    //or in another position to not watch them.

    Timer stateTimer;
    RectTransform positionGameScreen, positionHUD;  

    void Start()
    {
        positionGameScreen = GetComponent<RectTransform>();
        positionHUD = GameObject.Find("HUD").GetComponent<RectTransform>();
        stateTimer = GameObject.Find("Timer").GetComponent<Timer>();
    }

    void Update()
    {
        if (stateTimer.pause)
        {
            positionGameScreen.position = new Vector3(positionHUD.position.x + 1000, positionHUD.position.y + 1000);
        }
        else
            positionGameScreen.position = positionHUD.position;
    }
}
