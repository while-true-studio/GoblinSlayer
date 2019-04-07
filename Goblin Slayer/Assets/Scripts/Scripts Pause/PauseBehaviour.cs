using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class PauseBehaviour : MonoBehaviour
{

    public GameObject pauseScreen, gameScreen;
    public PlayerController player;
    private void Start()
    {
        DesactivePause();
    }
    public void ActivePause()
    {
        player.enabled = false;
        pauseScreen.SetActive(true);
        gameScreen.SetActive(false);
        Time.timeScale = 0f;
    }

    public void DesactivePause()
    {
        player.enabled = true;
        pauseScreen.SetActive(false);
        gameScreen.SetActive(true);
        Time.timeScale = 1f;
    }
}