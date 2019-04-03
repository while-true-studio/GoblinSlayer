using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class PauseBehaviour : MonoBehaviour
{
    
    public GameObject pauseScreen, gameScreen;
    public bool pauseActive;
    public GameManager gamemanager;
    public KeyCode exitKey;
    public int scene;

    private void Start()
    {
        DesactivePause();
    }
    private void Update()
    {
        if (pauseActive && Input.GetKeyDown(exitKey)) gamemanager.ChangeScene(scene);
    }
    public void ActivePause()
    {
        pauseScreen.SetActive(true);
        gameScreen.SetActive(false);
        Time.timeScale = 0f;
        pauseActive = true;
    }

    public void DesactivePause()
    {
        pauseScreen.SetActive(false);
        gameScreen.SetActive(true);
        Time.timeScale = 1f;
        pauseActive = false;
    }
}