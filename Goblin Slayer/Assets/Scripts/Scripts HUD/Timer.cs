using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {



    float startTime = 0;
    float pauseTime = 0;
    float pausedTime = 0;

    private bool paused = false;
    private void Start()
    {
        StartTimer();
    }
    public void StartTimer()
    {
        startTime = Time.time;
    }

    public float GetTime()
    {
        if (paused)
            return pauseTime - startTime;
        return Time.time - startTime - pausedTime;
    }

    public void Pause()
    {
        pauseTime = Time.time;
    }

    public void Resume()
    {
        pausedTime += (Time.time - pauseTime);
    }

    public void Reset()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        print(GetTime());

        if (Input.GetMouseButtonDown(0))
        {
            paused = !paused;
            if (paused)
                Resume();
            else Pause();
        }

    }

    //float currentTime { get; set; }
    //private bool activeTime = true;

    //public void PauseTime()
    //{

    //}
    //private void Update()
    //{
    //    if(activeTime)
    //    {
    //        currentTime += Time.time;
    //        print(currentTime);
    //    }
    //}
    //public void ResetTime()
    //{

    //}



}
