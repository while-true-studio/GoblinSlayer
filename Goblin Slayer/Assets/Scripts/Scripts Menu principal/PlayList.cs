using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayList : MonoBehaviour
{
    public AudioClip[] playList;
    private AudioSource headPhones;
    private AudioClip currClip;
    public int song = 0;
    public float timePlayDelayed;

	void Start ()
    {
        headPhones = GetComponent<AudioSource>();
        ChoiceRandomClip();
    }



    private void Update()
    {
        if (!headPhones.isPlaying)
        {
            NextSong();
        }

    }

    private void ChoiceRandomClip()
    {
        song = (int)Random.Range(0, playList.Length);
        currClip = playList[song];
        headPhones.clip = currClip;
        headPhones.Play();
    }

    private void NextSong()
    {
        if (song < playList.Length - 1) { song++; }
        else { song=0; }

        currClip = playList[song];
        headPhones.clip = currClip;
        headPhones.PlayDelayed(timePlayDelayed);
        headPhones.Play();
    }
}
