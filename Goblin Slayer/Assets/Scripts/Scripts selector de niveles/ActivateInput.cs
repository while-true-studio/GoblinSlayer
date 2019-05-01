using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateInput : MonoBehaviour
{
    private InputController inputController;
    private HUD hud;
    private SpriteRenderer spriteRenderer;
    public AudioClip EnterInLevel;

    private void Start()
    {
        GameObject go = GameObject.Find("LvlSelecter");
        inputController = go.GetComponent<InputController>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        GameObject Go = GameObject.Find("InfoPanel");
        hud = Go.GetComponent<HUD>();
        spriteRenderer.color = Color.black;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        inputController.InputStatus(false);
        hud.ActivePanel(true);
        spriteRenderer.color = Color.white;
        Camera.main.GetComponent<SoundEffectsMenu>().PlayEffect(EnterInLevel);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inputController.InputStatus(true);
        hud.ActivePanel(false);
        Camera.main.GetComponent<SoundEffectsMenu>().PlayWalkSound();
    }


}
