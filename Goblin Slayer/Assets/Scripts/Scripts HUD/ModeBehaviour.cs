using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerAttackManager))]
public class ModeBehaviour : MonoBehaviour {

    PlayerAttackManager mode;

    private void Start()
    {
        mode = GameObject.Find("Player").GetComponent<PlayerAttackManager>();
    }

    private void Update()
    {
        CurrentMode();
    }
    public void CurrentMode()
    {
        switch (mode.currentMode)
        {
            case PlayerAttackManager.Mode.Melee:
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(false);
                break;
            case PlayerAttackManager.Mode.Mage:
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(true);
                break;
        }
    }
}
