using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingMouse : MonoBehaviour {

    private Transform playerTransform;
    public Transform shieldTransform;
    private PlayerAttackManager playerAttackManager;
    private Vector3 originalScale;

    void Start()
    {
        playerTransform = GetComponent<Transform>();
        playerAttackManager = GetComponent<PlayerAttackManager>();
        originalScale = shieldTransform.localScale;
    }

    void Update()
    {
        if (playerAttackManager.GetLookAt().x < 0)
        {
            playerTransform.localScale = new Vector3(1, 1, 1);
            shieldTransform.localScale = new Vector3(-originalScale.x, -originalScale.y, 1);
        }
        else
        {
            playerTransform.localScale = new Vector3(-1, 1, 1);
            shieldTransform.localScale = new Vector3(originalScale.x, originalScale.y, 1);
        }
    }
}
