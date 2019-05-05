using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public float timer;
    public float timerToTeleport;
    public Transform ToTp;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Chaman")
        {
            timer += Time.deltaTime;
        }

        if (timer >= timerToTeleport && collision.tag == "Chaman")
        {
            collision.transform.position = ToTp.position;
            audioSource.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Chaman")
            timer = 0.0f;
    }
}
