using UnityEngine;

public class TutorialLauncher : MonoBehaviour
{
    public int ImageToActive;
    public int TextToActive;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player") || collision.name != "Player") return;
        GetComponentInParent<Tutorial>().SetActiveTutorial(ImageToActive, TextToActive);
        GetComponent<AudioSource>().Play();
    }
}