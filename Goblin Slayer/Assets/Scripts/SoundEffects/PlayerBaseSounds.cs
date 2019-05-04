using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseSounds : MonoBehaviour {

    private AudioSource audioSource;

    public AudioClip playerDead;
    public AudioClip Walk;
    public AudioClip Run;
    public AudioClip jump;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayEffect(AudioClip currCLip)
    {
        audioSource.clip = currCLip;
        audioSource.Play();
    }


    public void StopSounds(bool state)
    {
        if (state) { audioSource.Stop(); }
        else { audioSource.Play(); }
    }

    public bool IsPlayingSound()
    {
        return audioSource.isPlaying;
    }



}
