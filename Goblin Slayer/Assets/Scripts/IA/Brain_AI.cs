using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Brain_AI : MonoBehaviour
{
    private void Start()
    {
        RegisterCallbacks();
    }

    private void OnDestroy()
    {
        UnRegisterCallbacks();
    }


    protected abstract void RegisterCallbacks();
    protected abstract void UnRegisterCallbacks();
}