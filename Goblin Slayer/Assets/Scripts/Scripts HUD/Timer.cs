using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float totalTime = 0;
    public int currentTime;
    Text timer;
    public float pausedTime = 0;
    public bool pause = false;

    void Start()
    {
        timer = GetComponent<Text>();
    }

    void Update()
    {
        TotalTime();
        CurrentTime();

        if (pause)
        {
            PausedTime();
        }
        else
            timer.text = currentTime.ToString();

    }

    public void TotalTime()
    {
        totalTime += Time.deltaTime;        
    }

    public void PausedTime()
    {
        pausedTime += Time.deltaTime;
    }

    public int CurrentTime()
    {
        return currentTime = (int)totalTime - (int)pausedTime;
    }

    public void PauseMode()
    {
        pause = true;
    }

    public void Resume ()
    {
        pause = false;
    }

}
