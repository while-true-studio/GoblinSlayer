﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSounds : MonoBehaviour {

    private AudioSource audioSource;

    public AudioClip cast;
    public AudioClip meleeAttack;
    public AudioClip healingEffect;
    public AudioClip blockEffect;

	void Start ()
    {
        audioSource = GetComponent<AudioSource>();
	}
	
    public void PlayEffect (AudioClip currCLip)
    {
        audioSource.clip = currCLip;
        audioSource.Play();
    }


    public void StopSounds(bool state)
    {
        if (state) { audioSource.Stop(); }
        else { audioSource.Play(); }
    }

}
