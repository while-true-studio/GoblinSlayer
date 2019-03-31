using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerAttackManager : MonoBehaviour
{
    public enum Mode { Melee, Mage };
    public Mode currentMode;// { set; get; }
    
    public void SwitchMode()
    {
        currentMode = (Mode)((int)++currentMode%2);
    }
}
