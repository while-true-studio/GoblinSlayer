using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
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
    /// <param name="DIR"></param>
    public void MakeMovement(MOVEMENT DIR)
    {
        if (GameManager.instancia.currLevel + (int)DIR < 0 && GameManager.instancia.currLevel + (int)DIR > levels.Length) return;


        if (DIR == MOVEMENT.BACK && GameManager.instancia.currLevel>0)//&& levels[GameManager.instancia.currLevel + (int)DIR].levelPass
        {
            GameManager.instancia.NextLevel((int)DIR);
            levelSelect.ActiveLerp(levels[GameManager.instancia.currLevel].levelPosition);
        }
        else if(DIR == MOVEMENT.FORWARD && levels[GameManager.instancia.currLevel].levelPass)
        {
            GameManager.instancia.NextLevel((int)DIR);
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
