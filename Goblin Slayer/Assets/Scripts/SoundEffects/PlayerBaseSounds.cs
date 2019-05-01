using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseSounds : MonoBehaviour {

    private AudioSource audioSource;

    public AudioClip playerDead;
    public AudioClip Walk;
    public AudioClip Run;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayerDead()
    {
        audioSource.clip = playerDead;
        audioSource.Play();
    }

    public void PlayerWalk()
    {
        audioSource.clip = Walk;
        audioSource.Play();
    }

    public void PlayerRun()
    {
        audioSource.clip = Run;
        audioSource.Play();
    }

    public void StopAllSounds()
    {
        audioSource.Stop();
    }



}
