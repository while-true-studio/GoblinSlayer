using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Target_AI : MonoBehaviour
{
    private string targetName;
    private GameObject target;
    private void Awake()
    {
        target = GameObject.Find(targetName);
        Assert.IsNotNull(target, "ERROR: couldn't find object with name \"" + targetName + "\"");

    }
    public Transform GetTarget() { return target.transform; }
}
