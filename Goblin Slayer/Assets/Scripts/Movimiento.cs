using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour {

    public float velocity;    

	/// <summary>
    /// Prueba para el movimiento horizontal
    /// </summary>
	void Update ()
    {
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(velocity * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Translate(-velocity * Time.deltaTime, 0, 0);
        }
	}

    
}
