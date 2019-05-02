using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    private GameObject[] activators;
    public SpriteRenderer[] keys;
    public Text TextInCanvas;
    public Button yes,not;

    public string[] tutorialText;
    public int cont = 0;

	void Start ()
    {
        activators = new GameObject[transform.childCount];
        for (int i = 0; i<activators.Length;i++)
        {
            activators[i] = transform.GetChild(i).gameObject;
        }
	}
	
    public void SetActiveTutorial(int image,int text)
    {
        TextInCanvas.gameObject.SetActive(true);
        keys[image].gameObject.SetActive(true);
        TextInCanvas.text = tutorialText[text];

        if (image > 0)
        {
            keys[image - 1].gameObject.SetActive(false);
            activators[image - 1].GetComponent<Collider2D>().enabled = false;
        }
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SetHUD(true);
        TextInCanvas.text = "Do you want to see a tutorial ? ";
        Time.timeScale = 0;
    }


    public void ActiveTutorial(bool status)
    {
        GetComponent<Collider2D>().enabled = false;
        Time.timeScale = 1;
        SetHUD(false);
        if (!status)
        {
            for (int i = 0; i<activators.Length;i++)
            {
                activators[i].GetComponent<Collider2D>().gameObject.SetActive(false);
            }
        }
    }

    private void SetHUD(bool status)
    {
        TextInCanvas.gameObject.SetActive(status);
        yes.gameObject.SetActive(status);
        not.gameObject.SetActive(status);
    }

    private void StartGame()
    {
        TextInCanvas.gameObject.SetActive(false);
    }

    public void EndTutorial()
    {
        activators[activators.Length-1].GetComponent<Collider2D>().gameObject.SetActive(false);
        keys[keys.Length-1].gameObject.SetActive(false);
        TextInCanvas.text = "Now check your abilities killing goblins, do not leave any alive!";
        Invoke("StartGame",5);
    }

}
