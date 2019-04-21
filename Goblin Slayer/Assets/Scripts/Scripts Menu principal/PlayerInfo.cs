using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//TODO lerp entre white y negro del slogan
public class PlayerInfo : MonoBehaviour
{
    public InputField playerName;
    private string nameEntered = "Guest";
    public Renderer slogan;
    public float timeToRender;
    private float timerCenter;
    private float timerDown;
    private float timerMenu;
    private bool lerpCenter = true;
    private bool lerpDown = true;
    private Vector2 donwPos;
    public InputField nameField;


    private void Start()
    {
        donwPos = new Vector2(0, -2.3f);
    }
    /// <summary>
    /// Save the input field name
    /// </summary>
    /// <param name="nameEnter"></param>
    public void EnterPlayerName(string nameEnter)
    {
        if (nameEnter != "" && nameEnter!= "AllRecord" && nameEnter!= "AllRecord.txt")
            nameEntered = nameEnter;
    }
    
    /// <summary>
    /// Send the player name to GameManager when player changes the scene
    /// </summary>
    private void OnDisable()
    {
        GameManager.instancia.CurrentPlayer(nameEntered);
    }

    private void Update()
    {
        if (lerpCenter)
        {
            timerCenter += Time.deltaTime * timeToRender;
            slogan.material.SetColor("_Color", Color.Lerp(Color.clear, Color.white, timerCenter));
            lerpCenter = !(slogan.material.GetColor("_Color").a == Color.white.maxColorComponent);

        }

        if(!lerpCenter && lerpDown)
        {
            timerDown += Time.deltaTime * timeToRender;
            slogan.transform.position = Vector2.Lerp(slogan.transform.position,donwPos,timerDown);
            lerpDown = !(slogan.transform.position == (Vector3)donwPos);
        }
        else if(!lerpDown)
        {
            nameField.gameObject.SetActive(true);

        }
    }

    /// <summary>
    /// Active buttoms
    /// </summary>
    public void ActiveMenu()
    {
        transform.GetChild(1).gameObject.SetActive(true);
    }

}
