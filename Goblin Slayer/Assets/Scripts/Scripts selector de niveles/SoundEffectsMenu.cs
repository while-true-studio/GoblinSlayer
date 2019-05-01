using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsMenu : MonoBehaviour
{
    public AudioClip walk;
    private AudioSource headPhones;

	void Start ()
    {
        headPhones = GetComponent<AudioSource>();
	}
	


    public void PlayWalkSound()
    {
        headPhones.Stop();
        headPhones.clip = walk;
        headPhones.Play();
    }

    public void StopSounds()
    {
        headPhones.Stop();
    }

    public void PlayEffect(AudioClip currClip)
    {
        headPhones.clip = currClip;
        headPhones.Play();
    }
}
