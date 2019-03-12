using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

    /// <summary>
    /// Rotate the shield towards the mouse position
    /// </summary>
    /// <param name="direction">mousePosition</param>
    public void ShieldOrientation(Vector2 direction)
    {
        transform.LookAt(direction);
    }

    /// <summary>
    /// Active/Deactive the shield
    /// </summary>
    /// <param name="status">True = Actived / False = Deactived</param>
    public void ActiveShield(bool status)
    {
        //gameObject.SetActive(status);
    }
}
