using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeBehaviour : MonoBehaviour {

    //This variable is for testing, in the merge of the game
    //it will be changed by the real name of the script needed for this.
    TestMode modeChanger;

    void Start()
    {
        //The same case as before.
        modeChanger = GameObject.Find("Player").GetComponent<TestMode>();
    }
    void Update()
    {
        currentMode(modeChanger.mode);
    }

    /// <summary>
    /// It is absolutely necessary to keep an sctric order for to make this method works.
    /// </summary>
    public void currentMode(Mode mode)
    {
        switch (mode)
        {
            case Mode.melee:
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(false);
                break;
            case Mode.mage:
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(true);
                break;
        }
    }  
}
