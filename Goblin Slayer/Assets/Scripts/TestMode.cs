using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMode : MonoBehaviour {

    public Mode mode;
    public int selectMode = 0;
    public KeyCode keyMode;
    void Start()
    {
        mode = Mode.melee;
    }
    
    /// <summary>
    /// Temporally method to change mode
    /// </summary>
    public void ChangeMode()
    {
        selectMode++;
        if (selectMode >= 2) selectMode = 0;
        if (selectMode == 0) mode = Mode.melee;
        else if (selectMode == 1) mode = Mode.mage;
    }
}
