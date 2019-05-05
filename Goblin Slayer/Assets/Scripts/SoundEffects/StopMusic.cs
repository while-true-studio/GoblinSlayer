using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMusic : MonoBehaviour
{
    private BackMusicGame sounds;

    private void Start()
    {
        sounds = Camera.main.GetComponent<BackMusicGame>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sounds.StopAllSongs(true);
        }
    }

}
