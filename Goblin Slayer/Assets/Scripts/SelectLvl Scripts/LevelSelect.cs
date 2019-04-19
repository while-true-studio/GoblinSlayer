using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    private bool allow = false;
    private float time;
    private Vector2 goal;

	void Update ()
    {
        if (allow)
        {
            time = +Time.deltaTime * 0.9f;
            transform.position = Vector2.Lerp(transform.position, goal, time);
        }
        else time = 0.0f;
	}

    public void ActiveLerp(Vector2 goalDir)
    {
        goal = goalDir;
        allow = true;
    }

    public void DisarmLerp()
    {
        allow = false;
    }
}
