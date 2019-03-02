using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseElements : MonoBehaviour {

    //Script for positioning pause elements in the visual screen 
    //or in another position to not watch them.

    Timer stateTimer;
    RectTransform positionPauseScreen, positionCanvas;
    Vector3 startPosition;

    void Start()
    {
        positionPauseScreen = GetComponent<RectTransform>();
        positionCanvas = GameObject.Find("Canvas").GetComponent<RectTransform>();
        stateTimer = GameObject.Find("Timer").GetComponent<Timer>();
        startPosition = positionPauseScreen.position;
    }

    void Update()
    {
        if (stateTimer.pause)
        {
            positionPauseScreen.position = positionCanvas.position;
        }
        else
            positionPauseScreen.position = startPosition;
    }
}
