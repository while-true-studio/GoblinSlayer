using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    public Text info;
    public Text nameTxt;
    //public Text record;
    public GameObject panel;
    private string playerName;
    public Button close;
    public AudioClip pageBook;
    public LevelSelector levelSelector;


    /// <summary>
    /// Writes in HUD record
    /// </summary>
    /// <param name="bestRecord"></param>
    /// <param name="recordMan"></param>
    private void TextRecord(int bestRecord,string recordMan)
    {
    //TODO:Give record support
    //Code down below doesn't work right now
        /*
        if (bestRecord != 0)
            record.text = "The record belongs to " + recordMan+" in "+ bestRecord+" seconds";
        else record.text = "You are the first player in this level!";
        */
    }

    /// <summary>
    /// Writes in HUD player´s name
    /// </summary>
    /// <param name="playerName"></param>
    private void TextName()
    {
        nameTxt.text = playerName;
    }
    /// <summary>
    /// Writes in HUD player´s best time
    /// </summary>
    /// <param name="bestTime"></param>
    private void BestTime(TimeSpan bestTime)
    {
        if(bestTime.TotalSeconds > 0)
            info.text = "Your best time" + bestTime.TotalSeconds + "s";
        else info.text = "You have not played this level yet";
    }

    /// <summary>
    /// Set panel whit all player´s info
    /// </summary>
    /// <param name="status"></param>
    public void ActivePanel(bool status)
    {
        Camera.main.GetComponent<SoundEffectsMenu>().PlayEffect(pageBook);
        close.gameObject.SetActive(status);
        panel.SetActive(status);
        info.gameObject.SetActive(status);
        nameTxt.gameObject.SetActive(status);
        playerName = string.IsNullOrEmpty(PlayerInfoManager.GetCurrentPlayerInfo().Name) ? "Player": PlayerInfoManager.GetCurrentPlayerInfo().Name;
        TextName();
        BestTime(PlayerInfoManager.GetCurrentPlayerInfo().Levels[levelSelector.CurrentLevelIndex].time);
        //record.gameObject.SetActive(status);
        //TextRecord(GameManager.instancia.BestRecord(GameManager.instancia.currLevel),GameManager.instancia.BestRecordMan(GameManager.instancia.currLevel));
    }
}
