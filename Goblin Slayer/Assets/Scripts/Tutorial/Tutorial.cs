using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    private GameObject[] activators;

   
    public SpriteRenderer[] Keys;
    public Text TextInCanvas;
    public Button Yes;
    public Button Not;
    public AudioClip back;
    private AudioSource audioSource;

    public string[] TutorialText;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        activators = new GameObject[transform.childCount];
        for (var i = 0; i < activators.Length; i++)
        {
            activators[i] = transform.GetChild(i).gameObject;
        }
    }

    public void SetActiveTutorial(int image, int text)
    {
        TextInCanvas.gameObject.SetActive(true);
        Keys[image].gameObject.SetActive(true);
        TextInCanvas.text = TutorialText[text];
        
        if (image <= 0) return;
        Keys[image - 1].gameObject.SetActive(false);
        activators[image - 1].GetComponent<Collider2D>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // This should ignore anything that is not the Player, nor is named "Player" (fireballs have the Player tag).
        if (!collision.CompareTag("Player") || collision.name != "Player") return;
;
        audioSource.Play();
        SetHUD(true);
        TextInCanvas.text = "Do you want to see a tutorial ? ";
        Time.timeScale = 0;
    }


    public void ActiveTutorial(bool status)
    {
        audioSource.clip = back;
        audioSource.Play();
        GetComponent<Collider2D>().enabled = false;
        Time.timeScale = 1;
        SetHUD(false);
        
        if (status) return;
        foreach (var activator in activators)
        {
            activator.GetComponent<Collider2D>().gameObject.SetActive(false);
        }
    }

    private void SetHUD(bool status)
    {
        TextInCanvas.gameObject.SetActive(status);
        Yes.gameObject.SetActive(status);
        Not.gameObject.SetActive(status);
    }

    private void StartGame()
    {
        TextInCanvas.gameObject.SetActive(false);
    }

    public void EndTutorial()
    {
        activators[activators.Length - 1].GetComponent<Collider2D>().gameObject.SetActive(false);
        Keys[Keys.Length - 1].gameObject.SetActive(false);
        TextInCanvas.text = "Now check your abilities killing goblins, do not leave any alive!";
        Invoke("StartGame", 5);
    }
}