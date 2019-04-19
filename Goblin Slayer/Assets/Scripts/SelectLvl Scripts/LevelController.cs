using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public Nivel[] levels;
    public LevelSelect levelSelect;
    public ActiveLvls activeLvls;
    public enum MOVEMENT { BACK = -1,FORWARD = 1}

    public struct Nivel
    {
        public Vector2 levelPosition;
        public bool levelPass;
    }

    private int currLevel;


    void Start ()
    {
        currLevel = 0;
        levels = new Nivel[transform.childCount];
        for(int i = 0; i<levels.Length;i++)
        {
            levels[i].levelPass = false;
            levels[i].levelPosition = transform.GetChild(i).position;
        }
    }
	
    public void MakeMovement(MOVEMENT DIR)
    {
        if (currLevel + (int)DIR < 0 || currLevel + (int)DIR > levels.Length) return;

        if (DIR == MOVEMENT.BACK && levels[currLevel + (int)DIR].levelPass)
        {
            currLevel += (int)DIR;
            levelSelect.ActiveLerp(levels[currLevel].levelPosition);
        }
        else if(DIR == MOVEMENT.FORWARD && levels[currLevel].levelPass)
        {
            currLevel += (int)DIR;
            levelSelect.ActiveLerp(levels[currLevel].levelPosition);
        }
        else print("Nivel bloqueado");

    }

    public void ActiveLvl(int index)
    {
        levels[index].levelPass = true;
        activeLvls.ActiveSpriteLevel(index);
    }

    /// <summary>
    /// When player choice level
    /// </summary>
    public void SelectLevel()
    {
        GameManager.instancia.ChangeScene(currLevel+1);
    }
}
