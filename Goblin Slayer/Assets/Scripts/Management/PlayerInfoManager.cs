using System;
using System.IO;
using UnityEngine;

public struct PlayerInfo
{
    public PlayerInfo(string serialized)
    {
        string[] data = serialized.Split('\n');

        name = data[0];
        levels = new Level[GameManager.GetLevelsCount()];
        for (int i = 0; i < levels.Length; i++)
            levels[i] = new Level(data[i + 1]);

    }

    public PlayerInfo(string name, Level[] levels)
    {
        this.name = name;
        this.levels = levels;
    }

    public string Serialize()
    {
        string sLevels = "";
        foreach (var level in levels)
            sLevels += level.Serialize() + '\n';
        return name + '\n' + sLevels;

    }



    public struct Level
    {
        public Level(string serialized)
        {
            string[] data = serialized.Split(':');
            unlocked = data[0] == "true";
            time = TimeSpan.FromSeconds(double.Parse(data[1]));
        }

        public Level(TimeSpan time, bool unlocked)
        {
            this.unlocked = unlocked;
            this.time = time;
        }

        public string Serialize()
        {
            return unlocked.ToString() + ':' + time.TotalSeconds;
        }

        public TimeSpan time;
        public bool unlocked;

    }

    public string Name
    {
        get { return name; }
    }

    public Level[] Levels
    {
        get { return levels; }
    }

    private Level[] levels;
    private readonly string name;
}

public class PlayerInfoManager
{
    #region Singleton
    private static PlayerInfoManager _self = null;


    private static PlayerInfoManager self
    {
        get
        {
            if (_self == null)
                _self = new PlayerInfoManager();
            return _self;
        }
    }
    #endregion
    #region API

    public static bool LoadData(string name)
    {
        return self._LoadData(name);
    }
    

    public static void SaveData()
    {
        self._SaveData();
    }
    #endregion

#if UNITY_EDITOR
    private readonly string path = Application.dataPath;
#else
    private readonly string path = Application.persistentDataPath;
#endif

    private PlayerInfoManager()
    {
        path += "/Saves/";
    }

    public PlayerInfo playerInfo;

    /// <summary>
    /// Loads the player data
    /// </summary>
    /// <param name="name">The name of the player</param>
    /// <returns>true if the save file existed, false if not</returns>
    private bool _LoadData(string name)
    {
        string fullPath = path + name + ".save";

        if (!File.Exists(fullPath)) return false;

        var stream = new StreamReader(fullPath);
        string data = stream.ReadToEnd();
        playerInfo = new PlayerInfo(data);

        return true;
    }



    private void _SaveData()
    {
        string fullPath = path + playerInfo.Name + ".save";
        string serializedInfo = "";
        //si ya se ha guardado esta partida 
        if (File.Exists(fullPath))
        {
            //Abrir el antigua guardado
            var reader  = new StreamReader(fullPath);
            PlayerInfo fileInfo = new PlayerInfo(reader.ReadToEnd());
            reader.Close();
            //Actualizar con los mejores tiempos

            for (int i = 0; i < playerInfo.Levels.Length; i++)
            {
                var level = playerInfo.Levels[i];
                var fileLevel = fileInfo.Levels[i];
                if (!level.unlocked) continue;

                if (fileLevel.unlocked)
                    fileLevel.time = level.time < fileLevel.time ? level.time : fileLevel.time;
                else
                {
                    fileLevel.unlocked = true;
                    fileLevel.time = level.time;
                }
            }

            serializedInfo = fileInfo.Serialize();
        }
        else //Creamos un nuevo fichero de guardado
        {
            serializedInfo = playerInfo.Serialize();
        }
        //Guardamos la partida
        var writer = new StreamWriter(fullPath, false);
        writer.Write(serializedInfo);
        writer.Flush();
        writer.Close();
    }
}
