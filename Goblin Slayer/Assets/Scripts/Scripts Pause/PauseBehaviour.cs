using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseBehaviour : MonoBehaviour
{
    public KeyCode pauseCode = KeyCode.Escape;
    public GameObject pauseScreen, gameScreen;
    public PlayerController playerController;
    public LookingMouse playerLook;

    private bool paused = false;

    private void Start()
    {
        DeactivePause();
    }

    private void Update()
    {
        if (Input.GetKeyDown(pauseCode))
        {
            if (paused)
                DeactivePause();
            else
                ActivePause();

            paused = !paused;

        }
    }

    public void ActivePause()
    {
        playerController.enabled = false;
        playerLook.enabled = false;
        pauseScreen.SetActive(true);
        gameScreen.SetActive(false);
        Time.timeScale = 0f;
    }

    public void DeactivePause()
    {
        playerController.enabled = true;
        playerLook.enabled = true;
        pauseScreen.SetActive(false);
        gameScreen.SetActive(true);
        Time.timeScale = 1f;
    }
    public void MuteMusic()
    {
        AudioListener.pause = !AudioListener.pause;

    }
}