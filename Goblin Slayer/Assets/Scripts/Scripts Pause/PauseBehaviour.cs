using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class PauseBehaviour : MonoBehaviour
{

    public GameObject pauseScreen, gameScreen;
    public PlayerController playerController;
    public LookingMouse playerLook;
    private void Start()
    {
        DesactivePause();
    }
    public void ActivePause()
    {
        playerController.enabled = false;
        playerLook.enabled = false;
        pauseScreen.SetActive(true);
        gameScreen.SetActive(false);
        Time.timeScale = 0f;
    }

    public void DesactivePause()
    {
        playerController.enabled = true;
        playerLook.enabled = true;
        pauseScreen.SetActive(false);
        gameScreen.SetActive(true);
        Time.timeScale = 1f;
    }
}