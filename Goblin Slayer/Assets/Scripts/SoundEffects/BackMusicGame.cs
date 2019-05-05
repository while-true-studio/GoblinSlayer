using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackMusicGame : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip startSong;
    public AudioClip battleSong;
    public AudioClip bossSong;
    private AudioClip currClip;
    public float timeBypass;
    private float timer, maxVol, minVol;
    public bool newSong;

	void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        maxVol = audioSource.volume;
        minVol = 0;
	}

    private void Update()
    {
        if (newSong)
        {
            timer += Time.deltaTime * timeBypass;
            audioSource.volume = Mathf.Lerp(maxVol,minVol,timer);
        }
        else { timer = 0; }
    }


    public void PlaySong(AudioClip clip)
    {
        print(clip.name);
        newSong = true;
        currClip = clip;
        Invoke("PlaySongInTime",4);
    }

    private void SwapVol()
    {
        float aux = maxVol;
        maxVol = minVol;
        minVol = aux;
    }

    private void PlaySongInTime()
    {
        //SwapVol();
        audioSource.clip = currClip;
        audioSource.volume = maxVol;
        audioSource.Play();
        newSong = false;
        //Invoke("StopLerp",2);
    }

    private void StopLerp()
    {
        newSong = false;
    }

    public void StopAllSongs(bool status)
    {
        if (status) { newSong = true; }
        else { audioSource.Play(); }
    }

    public bool IsPlayingSong()
    {
        return audioSource.isPlaying;
    }

    
}
