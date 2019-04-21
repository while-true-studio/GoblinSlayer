using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float totalTime = 0; //The total time from the begining of the level.
    public int currentTime { get; private set; } //The current time while playing mode.
    Text timer; //To show up the currentTime.
    public float pausedTime = 0; //the time while the pause mode.
    public bool pause = false; //It will be true when the pause mode goes up 
    public bool finishLevel = false; //It will be true when the level is finished

    void Start()
    {
        timer = GetComponent<Text>();
    }

    void Update()
    {
        if (!finishLevel)
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
    }

    /// <summary>
    /// Add 1 second to totalTime every second 
    /// from the begining to the end.
    /// </summary>
    public void TotalTime()
    {
        totalTime += Time.deltaTime;        
    }

    /// <summary>
    /// Add 1 second to pausedTime every second 
    /// in pause mode.
    /// </summary>
    public void PausedTime()
    {
        pausedTime += Time.deltaTime;
    }

    /// <summary>
    /// The operation to set currentTime.
    /// </summary>
    public void CurrentTime()
    {
        currentTime = (int)totalTime - (int)pausedTime;
    }

    /// <summary>
    /// When the button is pressed the pause mode starts
    /// </summary>
    public void PauseMode()
    {
        pause = true;
    }

    /// <summary>
    /// When the button is pressed the pause mode finishs.
    /// </summary>
    public void Resume ()
    {
        pause = false;
    }

    public void Finished()
    {
        finishLevel = true;
    }

}
