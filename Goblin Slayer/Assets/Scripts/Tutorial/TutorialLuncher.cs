using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialLuncher : MonoBehaviour
{
    public int imageToActive;
    public int TextToActive;


    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.CompareTag("Player"))
        GetComponentInParent<Tutorial>().SetActiveTutorial(imageToActive,TextToActive);
    }
}
