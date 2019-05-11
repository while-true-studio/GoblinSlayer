﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{

    public KeyCode next = KeyCode.D;
    public KeyCode previous = KeyCode.A;
    public KeyCode enter = KeyCode.Return;

    public Transform[] levelsPosition;
    public AudioClip enterInLevelAudioClip;

    public int CurrentLevelIndex
    {
        get { return currentLevelIndex; }
        set { currentLevelIndex = (value % GameManager.GetLevelsCount()); }
    }

    private int currentLevelIndex = 0;
    private bool moving = false;
    private SoundEffectsMenu soundEffects;
    private PlayerInfo.Level[] levelsInfo;

    private void Start()
    {
        CurrentLevelIndex = 0;
        soundEffects = Camera.main.GetComponent<SoundEffectsMenu>();
        levelsInfo = PlayerInfoManager.GetCurrentPlayerInfo().Levels;
    }

    private void Update()
    {
        if (moving) return;

        if (Input.GetKeyDown(next) /*&& levelsInfo[CurrentLevelIndex + 1].unlocked*/)
        {
            CurrentLevelIndex++;
            GoToLevel();
        }
        else if (Input.GetKeyDown(previous) /*&& levelsInfo[CurrentLevelIndex - 1].unlocked*/)
        {
            CurrentLevelIndex--;
            GoToLevel();
        }
        else if (Input.GetKeyDown(enter))
        {
            soundEffects.PlayEffect(enterInLevelAudioClip);
            GameManager.ChangeScene(GameManager.LevelIndexToScene(CurrentLevelIndex));
        }
    }


    private IEnumerator Move(Transform from, Transform to)
    {
        moving = true;
        soundEffects.PlayWalkSound();

        while (Vector3.Distance(from.position, to.position) > 0.1)
        {
            Vector3 pos = Vector3.Lerp(from.position, to.position, Time.deltaTime);
            from.position = pos;
            yield return null;
        }
        from.position = to.position;
        moving = false;
    }

    private void GoToLevel()
    {
        IEnumerator move = Move(transform, levelsPosition[currentLevelIndex]);
        StartCoroutine(move);
    }
    //private bool 


}

/*
public class LevelSelector : MonoBehaviour
{
    public Nivel[] levels;
    public LevelSelect levelSelect;
    public ActiveLvls activeLvls;
    public enum MOVEMENT { BACK = -1,FORWARD = 1}
    public int maxLevelActive;


    public struct Nivel
    {
        public Vector2 levelPosition;
        public bool levelPass;
    }


    void Start ()
    {
        levels = new Nivel[transform.childCount];
        for(int i = 0; i<levels.Length;i++)
        {
            levels[i].levelPass = false;
            levels[i].levelPosition = transform.GetChild(i).position;
        }
        if(GameManager.instancia.currLevel>1)
            ActiveLvl(GameManager.instancia.currLevel);

        WhatLevelIsActive();
    }

    /// <summary>
    /// Add or remove positions in the level´s selection
    /// </summary>
    /// <param name="direction"></param>
    public void MakeMovement(MOVEMENT direction)
    {
        if (GameManager.instancia.currLevel + (int)direction < 0 && GameManager.instancia.currLevel + (int)direction > levels.Length) return;


        if (direction == MOVEMENT.BACK && GameManager.instancia.currLevel>0)//&& levels[GameManager.instancia.currLevel + (int)direction].levelPass
        {
            GameManager.instancia.NextLevel((int)direction);
            levelSelect.ActiveLerp(levels[GameManager.instancia.currLevel].levelPosition);
        }
        else if(direction == MOVEMENT.FORWARD && levels[GameManager.instancia.currLevel].levelPass)
        {
            GameManager.instancia.NextLevel((int)direction);
            levelSelect.ActiveLerp(levels[GameManager.instancia.currLevel].levelPosition);
        }
        else print("Nivel bloqueado");

    }

    /// <summary>
    /// Activates everything necessary to activate a level
    /// </summary>
    /// <param name="index"></param>
    public void ActiveLvl(int index)
    {
        levels[index].levelPass = true;
        activeLvls.ActiveSpriteLevel(index);
    }

    public void FastActive(int index)
    {
        for(int i = 0; i<index;i++)
        {
            levels[i].levelPass = true;
            activeLvls.FastActiveSprite(index);
        }
    }

    /// <summary>
    /// When player choice level
    /// </summary>
    public void SelectLevel()
    {
        GameManager.instancia.ChangeScene(GameManager.instancia.currLevel+1 );
    }

    /// <summary>
    /// activate all levels that have saved time
    /// </summary>
    public void WhatLevelIsActive()
    {
        int cont = 1;
        while(GameManager.instancia.BestTime(cont)>0.0f)
        {
            ActiveLvl(cont);
            cont++;
        }
    }


}
*/