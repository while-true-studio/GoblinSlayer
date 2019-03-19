using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class PauseBehaviour : MonoBehaviour
{

    public GameObject pauseScreen, gameScreen;
    bool pauseMode;

    private void Start()
    {
        DesactivePause();        
    }

    public void ActivePause()
    {
        pauseScreen.SetActive(true);
        gameScreen.SetActive(false);
        pauseMode = true;
    }

    public void DesactivePause()
    {
        pauseScreen.SetActive(false);
        gameScreen.SetActive(true);
        pauseMode = false;
    }

    /// <summary>
    /// A solution to freezing the screen.
    /// </summary>
    public void Freeze()
    {
        if (pauseMode) Time.timeScale = 0;
        else Time.timeScale = 1;
    }
}