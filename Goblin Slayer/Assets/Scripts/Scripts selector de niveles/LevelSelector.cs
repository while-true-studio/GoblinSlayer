using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;

public class LevelSelector : MonoBehaviour
{

    public KeyCode next = KeyCode.D;
    public KeyCode previous = KeyCode.A;
    public KeyCode enter = KeyCode.Return;

    public Transform[] levelsPosition;
    public AudioClip enterInLevelAudioClip;
    public float iconVelocity;
    public bool allLevelsUnlocked = false;

    public int CurrentLevelIndex
    {
        get { return currentLevelIndex; }
        set { currentLevelIndex = (value % GameManager.GetLevelsCount()); }
    }

    public int NextLevelIndex()
    {
        return (currentLevelIndex + GameManager.GetLevelsCount() + 1) % GameManager.GetLevelsCount();
    }

    public int PreviousLevelIndex()
    {
        return (currentLevelIndex + GameManager.GetLevelsCount() - 1) % GameManager.GetLevelsCount();
    }

    public int currentLevelIndex = 0;
    private bool moving = false;
    private SoundEffectsMenu soundEffects;
    private PlayerInfo.Level[] levelsInfo = null;

    private void Start()
    {
        CurrentLevelIndex = 0;
        soundEffects = Camera.main.GetComponent<SoundEffectsMenu>();
        levelsInfo = PlayerInfoManager.GetCurrentPlayerInfo().Levels;
        Assert.IsNotNull(levelsInfo, "Error: Couldn't find the levelsInfo in LevelSelector\n<color=yellow>Tip: is PlayerInfoManager initialized?</color>");
    }

    private void Update()
    {
        if (moving) return;

        if (Input.GetKeyDown(previous)  && (levelsInfo[PreviousLevelIndex()].unlocked || allLevelsUnlocked))
        {
            CurrentLevelIndex = PreviousLevelIndex();
            MoveIcon();
        }
        else if (Input.GetKeyDown(next) && (levelsInfo[NextLevelIndex()].unlocked     || allLevelsUnlocked))
        {
            CurrentLevelIndex = NextLevelIndex();
            MoveIcon();
        }
        else if (Input.GetKeyDown(enter))
        {
            soundEffects.PlayEffect(enterInLevelAudioClip);
            if (levelsInfo[currentLevelIndex].unlocked)
                GameManager.ChangeScene(GameManager.LevelIndexToScene(CurrentLevelIndex));
        }
    }

    private void MoveIcon()
    {
        StartCoroutine(Move(transform, levelsPosition[currentLevelIndex]));
    }

    private IEnumerator Move(Transform from, Transform to)
    {
        moving = true;
        soundEffects.PlayWalkSound();

        while (Vector3.Distance(from.position, to.position) > 0.1)
        {
            Vector3 pos = from.position;
            Vector3 dir = (to.position - from.position).normalized;
            pos += dir * iconVelocity * Time.deltaTime;
            from.position = pos;
            yield return null;
        }
        from.position = to.position;
        moving = false;
    }

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