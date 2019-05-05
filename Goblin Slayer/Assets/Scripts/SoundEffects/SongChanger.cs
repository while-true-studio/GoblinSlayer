using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongChanger : MonoBehaviour
{
    private BackMusicGame music;
    public AudioClip clip;

	void Start ()
    {
        music = Camera.main.GetComponent<BackMusicGame>();
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            music.PlaySong(clip);
            Destroy(gameObject);
        }
    }
}
