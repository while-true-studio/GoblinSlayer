using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CameraFreeMovement))]
[RequireComponent(typeof(CameraFollowTarget))]
public class CameraMovementManager : MonoBehaviour
{
    private CameraFollowTarget followTarget;
    private CameraFreeMovement freeMovement;

    public enum CameraMovement
    {
        FOLLOW_TARGET,
        FREE_MOVEMENT
    }

    private CameraMovement currentCameraMovement = CameraMovement.FOLLOW_TARGET;

	void Start ()
    {
        followTarget = GetComponent<CameraFollowTarget>();
        freeMovement = GetComponent<CameraFreeMovement>();
    }

    public void ToggleCameraMovement()
    {
        currentCameraMovement = (CameraMovement) (((int)currentCameraMovement + 1)%2);
        SetCameraMovement(currentCameraMovement);
    }

    public void SetCameraMovement(CameraMovement movement)
    {
        followTarget.enabled = !(freeMovement.enabled = movement == CameraMovement.FREE_MOVEMENT);
    }
}
