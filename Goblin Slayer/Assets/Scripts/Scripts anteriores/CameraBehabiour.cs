using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehabiour : MonoBehaviour
{
    public Transform target;

	
	void Update ()
    {
        transform.position = new Vector3(target.position.x+1.5f,target.position.y + 1.5f, -10.0f);
	}
}
