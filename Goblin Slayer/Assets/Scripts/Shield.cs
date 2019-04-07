using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

    private PlayerAttackManager playerAttackManager;
    public GameObject shieldSprite;
    private Animator shieldAnim;

    void Start()
    {
        playerAttackManager = GetComponent<PlayerAttackManager>();
        shieldAnim = transform.GetChild(0).GetComponent<Animator>();
        ActiveShield(false);
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
        if (direction.y > -0.4) shieldSprite.transform.SetPositionAndRotation(transform.localPosition + move, Quaternion.AngleAxis(angle, Vector3.forward));
    }

    /// <summary>
    /// Active/Deactive the shield
    /// </summary>
    /// <param name="status">True = Actived / False = Deactived</param>
    public void ActiveShield(bool status)
    {
        shieldSprite.SetActive(status);
        shieldAnim.SetBool("Guard",status);
    }
}
