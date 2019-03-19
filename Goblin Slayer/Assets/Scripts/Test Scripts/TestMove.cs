using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour {

    public float speed = 2.0f;
    public float imagBound;
    PauseBehaviour pause;
    private void Start()
    {
        pause = GameObject.Find("HUD").GetComponent<PauseBehaviour>();
    }

    void Update ()
    {
        transform.Translate(speed * Time.deltaTime, 0f, 0);
        pause.Freeze();
        if (transform.position.x >= imagBound || transform.position.x < -imagBound)
            speed = -speed;
	}
}
