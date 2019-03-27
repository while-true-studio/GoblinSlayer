using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

    private PlayerAttackManager playerAttackManager;
    public GameObject shieldSprite;

    void Start()
    {
        playerAttackManager = GetComponent<PlayerAttackManager>();
    }
    void Update()
    {
        ShieldMovement(playerAttackManager.GetLookAt());
    }

    /// <summary>
    /// Rotate the shield towards the mouse position
    /// </summary>
    /// <param name="direction">mousePosition</param>
    public void ShieldMovement(Vector2 direction)
    {
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Vector3 move = new Vector3(direction.x, direction.y, 0);
        if (direction.x > 0.2)
        {
            shieldSprite.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            shieldSprite.transform.position = transform.localPosition + move;
        }
        
    }

    /// <summary>
    /// Active/Deactive the shield
    /// </summary>
    /// <param name="status">True = Actived / False = Deactived</param>
    public void ActiveShield(bool status)
    {
        shieldSprite.SetActive(status);
    }
}
