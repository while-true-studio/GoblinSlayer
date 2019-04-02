using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class PauseBehaviour : MonoBehaviour
{
    
    public GameObject pauseScreen, gameScreen;
    private void Start()
    {
        DesactivePause();
    }

    public void ActivePause()
    {
        pauseScreen.SetActive(true);
        gameScreen.SetActive(false);
        Time.timeScale = 0f;
    }

    public void DesactivePause()
    {
        pauseScreen.SetActive(false);
        gameScreen.SetActive(true);
        Time.timeScale = 1f;
    }
}