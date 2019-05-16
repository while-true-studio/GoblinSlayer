using System;
using System.IO;
using System.Security.Policy;
using UnityEngine;
// ReSharper disable All

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

    /// <summary>
    /// Initializes PlayerInfo
    /// </summary>
    /// <param name="name">Player's name used to be the file handle</param>
    /// <param name="levels">The data of the levels. If null, a default counstructor will make one with the forst level unlocked</param>

    public PlayerInfo(string name, Level[] levels)
    {
        this.name = name;
        if (levels == null)
        {
            levels = new Level[GameManager.GetLevelsCount()];
            levels[0].unlocked = true;
        }
        this.levels = levels;
    }

    public string Serialize()
    {
        string sLevels = "";
        foreach (var level in levels)
            sLevels += '\n' + level.Serialize();
        return name + sLevels;

    }

    public struct Level
    {

        public Level(string serialized)
        {
            string[] data = serialized.Split(':');
            //unlocked = data[0] == "true";
            unlocked = data[0].Equals("true", StringComparison.InvariantCultureIgnoreCase);
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

/*
public struct Record
{
    private PlayerInfo.Level[] levels;
}
*/

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

    public static PlayerInfo GetCurrentPlayerInfo()
    {
        return self.currentPlayerInfo;
    }

    public static void SetCurrentPlayerInfo(PlayerInfo playerInfo)
    {
        self.currentPlayerInfo = playerInfo;
    }

    public static void LoadData(string name)
    {
        self._LoadData(name);
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

    private PlayerInfo currentPlayerInfo;
    private PlayerInfo record;
    /// <summary>
    /// Loads the player data
    /// </summary>
    /// <param name="name">The name of the player</param>
    /// <returns>true if the save file existed, false if not</returns>
    private void _LoadData(string name)
    {
        string fullPath = path + name + ".save";
        bool found = File.Exists(fullPath);

        if (found)
        {
            var stream = new StreamReader(fullPath);
            string data = stream.ReadToEnd();
            currentPlayerInfo = new PlayerInfo(data);
            stream.Close();
        }
        else
        {
            currentPlayerInfo = new PlayerInfo(name, null);
        }
        //Debug.LogFormat("Trying to load file: {0}\n{1}", fullPath, found ? "<color=green>Found</color>" : "<color=red>Not found</color> -> Creating a default PlayerInfo");
        //Debug.LogFormat("Loaded data:\n{0}", currentPlayerInfo.Serialize());
    }

    private void _SaveData()
    {
        string fullPath = path + currentPlayerInfo.Name + ".save";
        //Debug.Log("Trying to save file: " + fullPath);
        string serializedInfo = "";
        //si ya se ha guardado esta partida 
        if (File.Exists(fullPath))
        {
            //Abrir el antigua guardado
            var reader = new StreamReader(fullPath);
            PlayerInfo fileInfo = new PlayerInfo(reader.ReadToEnd());
            reader.Close();
            //Actualizar con los mejores tiempos

            for (int i = 0; i < currentPlayerInfo.Levels.Length; i++)
            {
                var level = currentPlayerInfo.Levels[i];
                var fileLevel = fileInfo.Levels[i];
                if (!level.unlocked) continue;
                //TODO: comprobar si la comprobación es correcta o si siempre coge la del
                //fichero porque 0 (valor por defecto del timepo)< cualquier otro número
                if (fileLevel.unlocked && (fileLevel.time > level.time || Math.Abs(fileLevel.time.TotalSeconds) < double.Epsilon))
                    fileLevel.time = level.time;
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
            Directory.CreateDirectory(path);
            serializedInfo = currentPlayerInfo.Serialize();
        }
        //Debug.LogFormat("Saved data:\n{0}", serializedInfo);
        //Guardamos la partida
        var writer = new StreamWriter(fullPath, false);
        writer.Write(serializedInfo);
        writer.Flush();
        writer.Close();
    }
}
