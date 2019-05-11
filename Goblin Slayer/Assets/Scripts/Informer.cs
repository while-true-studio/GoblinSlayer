using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Informer : MonoBehaviour
{
    public string stillGoblinsAliveMessage;
    public string allGoblinsDeadMessage;
    public Text informerText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        informerText.gameObject.SetActive(true);

        if (collision.CompareTag("Player") && !GameplayManager.IsLevelClear())
        {
            informerText.text = stillGoblinsAliveMessage;
        }
        else
        {
            informerText.text = allGoblinsDeadMessage;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        informerText.gameObject.SetActive(false);
        informerText.text = "";
    }

}
