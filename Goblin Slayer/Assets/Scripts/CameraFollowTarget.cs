using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTarget : MonoBehaviour
{
    public Transform target;
    private float distance;
    public float difference = 1.5f;

    public void Start()
    {
        distance = transform.position.z - target.position.z;
    }

    void Update ()
    {
        transform.position = new Vector3(target.position.x + difference, target.position.y+difference, distance);

	}
}