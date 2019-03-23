using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRage : MonoBehaviour {

    Rage rage;
    public bool testBool;
    public int plusRage;


    void Start()
    {
        rage = GetComponent<Rage>();
    }

	void Update ()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            rage.AddRage(plusRage);
            print("Rage won: " + plusRage);
            print("Current rage: " + rage.currentRage);
        }       
    }
}
