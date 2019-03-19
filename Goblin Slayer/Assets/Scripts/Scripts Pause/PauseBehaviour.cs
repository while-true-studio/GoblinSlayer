using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class PauseBehaviour : MonoBehaviour
{

    //Script for positioning pause elements in the visual screen 
    //or in another position to not watch them.

    //The order of the HUD's children in Hierarchy
    //is the most important thing to use this script.
    //It will activate or desactivate the GOs in function of an strict order.
    bool pauseMode;
    private void Start()
    {
        DesactivePause();
    }

    public void ActivePause()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);
        //transform.GetChild(2).gameObject.SetActive(false);
        //transform.GetChild(3).gameObject.SetActive(false);
        pauseMode = true;
    }

    public void DesactivePause()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
        //transform.GetChild(2).gameObject.SetActive(true);
        //transform.GetChild(3).gameObject.SetActive(true);
        pauseMode = false;
    }

    public void Freeze()
    {
        if (pauseMode) Time.timeScale = 0;
        else Time.timeScale = 1;

    }
}