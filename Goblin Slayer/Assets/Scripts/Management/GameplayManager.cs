using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System;
using UnityEngine;
using UnityEngine.Assertions;

public class GameplayManager : MonoBehaviour
{
    private static GameplayManager _self = null;

    public Timer timer;
    public Scene scene;
    public DoorKeeper doorKeeper;
    private int levelIndex;
    [SerializeField]
    private int enemiesAlive = 0;
    [SerializeField]
    private int spawnsAlive = 0;

    private void Awake()
    {
        _self = this;
        levelIndex = scene - Scene.LEVEL_1;
    }

    public static void OnSpawnCreated()
    {
        _self.spawnsAlive++;
    }

    public static void OnSpawnActivated()
    {
        _self.spawnsAlive--;
    }

    public static void OnEnemySpawn()
    {
        _self.enemiesAlive++;
    }
    public static void OnEnemyDead()
    {
        _self.enemiesAlive--;
        if(IsLevelClear())
            _self.doorKeeper.OpenNextLvl();
    }

    public static void OnGameOver()
    {
        _self.GameOver();
    }

    public static bool IsLevelClear()
    {
        return _self.enemiesAlive == 0 && _self.spawnsAlive == 0;
    }

    private void GameOver()
    {
        // Player Won the level
        if (IsLevelClear())
        {
            PlayerInfo playerInfo = PlayerInfoManager.GetCurrentPlayerInfo();

            TimeSpan time = TimeSpan.FromSeconds(timer.totalTime);
            TimeSpan oldTime = playerInfo.Levels[levelIndex].time;
            
            //Actualizar récord si se ha batido o si no existia(oldTime == 0)
            if (time < oldTime || Math.Abs(oldTime.TotalSeconds) < float.Epsilon)
                playerInfo.Levels[levelIndex].time = time;

            // Desbloquear siguiente nivel si es necesario  si quedan niveles por desbloquear
            if ((levelIndex + 1) < GameManager.GetLevelsCount())
                playerInfo.Levels[levelIndex + 1].unlocked = true;
            PlayerInfoManager.SetCurrentPlayerInfo(playerInfo);
            GameManager.Save();
        }
        //Ir a la pantalla de selección de nivel
        GameManager.ChangeScene(Scene.SELECT_LEVEL);
    }

}
