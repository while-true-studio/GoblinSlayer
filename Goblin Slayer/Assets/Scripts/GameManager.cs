using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Security.Permissions;



public enum Scene
{
    MAIN_MENU,
    SELECT_LEVEL,
    LEVEL_1,
    LEVEL_2,
    LEVEL_3
}

public class GameManager : MonoBehaviour
{

    #region Singleton
    private static GameManager self = null;

    private void Awake()
    {
        if (self == null)
        {
            self = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }
    #endregion

    #region API

    public static int GetLevelsCount()
    {
        return self.levelsCount;
    }

    public static void ResetLevel()
    {
        //FIX-ME: Make this nicer instead of reloading all scene again
        SceneManager.LoadScene((int)self.currentScene);
    }
    public static void ChangeScene(Scene scene)
    {
        self.currentScene = scene;
        SceneManager.LoadScene((int)self.currentScene);
    }

    public static void Save()
    {
        PlayerInfoManager.SaveData();
    }

    public static bool Load(string playerName)
    {
        return PlayerInfoManager.LoadData(playerName);
    }

    #region Events

    public static void OnEnemySpawn()
    {
        self.EnemiesAlive++;
    }
    public static void OnEnemyDead()
    {
        if (--self.EnemiesAlive <= 0)
            ChangeScene(Scene.SELECT_LEVEL);
    }

    public static void OnGameOver()
    {
    }



    #endregion
    #endregion

    #region Members
    
    private Scene currentScene;
    public int levelsCount;
    private int EnemiesAlive { get; set; }

    #endregion


    #region Implementation

   

    #endregion

}


/*
public class GameManager : MonoBehaviour
{
    public static GameManager instancia = null;
    public int EnemyDefeated;
    public int TotalEnemy;
    public string playerName{ get; private set; }
    public int currLevel;
    public int totalLevel = 3;
    public int maxLevel = 0;
    private playerInfo[] allInfoLevels;
    public bool IsGateOpen { get; private set; }
    struct playerInfo
    {
        public string recordMan;
        public int level;
        public float time;
        public float record;
    }

	private void Awake ()
    {
		if(instancia == null)
        {
            instancia = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
	}

    private void Start()
    {
        IsGateOpen = false;
        currLevel = 0;
        allInfoLevels = new playerInfo[totalLevel];
    }


    public void GameOver()
    {
        DamageScreen gameOver = Camera.main.GetComponent<DamageScreen>();
        gameOver.gameOver = true;
    }
    /// <summary>
    /// Count all Goblins
    /// </summary>
    /// <param name="amount"></param>
    public void AddTotalEnemy(int amount)
    {
        TotalEnemy += amount;
    }

    /// <summary>
    /// Open the gate for the next level if player defeated all goblins
    /// </summary>
    public void AddEnemy()
    {
        EnemyDefeated++;
        if(EnemyDefeated==TotalEnemy)
        {
            IsGateOpen = true;
            GameObject Go = GameObject.Find("DoorLvl");
            Go.GetComponent<DoorKeeper>().OpenNextLvl();
        }

    }

    /// <summary>
    /// Save player info in txt and unlock next level
    /// </summary>
    public void OnWinLevel()
    {
        Timer Go = GameObject.Find("Timer").GetComponent<Timer>();
        float aux = Go.currentTime;

        if (allInfoLevels[currLevel].time > aux)
        {
            allInfoLevels[currLevel].time = aux;
            ReWritePlayerTime();
        }

        if (allInfoLevels[currLevel].record > allInfoLevels[currLevel].time)
            NewRecord(aux);
        StartCoroutine(ActiveNextLvl());
        ChangeScene(4);

    }

    /// <summary>
    /// Activete next level in level select
    /// </summary>
    /// <returns></returns>
    private IEnumerator ActiveNextLvl()
    {
        yield return new WaitForSecondsRealtime(3.0f);
        if (currLevel > maxLevel) { maxLevel++;  }
        LevelController Go = GameObject.Find("Lvlpositions").GetComponent<LevelController>();
        Go.ActiveLvl(currLevel);

    }

    /// <summary>
    /// Reseteara la escena si  la vida del jugador es 0 o inferior 
    /// </summary>
    /// <param name="index">
    /// Indica qué escena se va a reiniciar
    /// </param
    public void ResetScene(int index)
    {
        StartCoroutine(ResetSceneInSeconds(index));
    }
   

    public IEnumerator ResetSceneInSeconds(int index)
    {
        yield return new WaitForSecondsRealtime(1);
        ChangeScene(index);
    }
    /// <summary>
    /// Change scene
    /// </summary>
    /// <param name="scene"></param>
    public void ChangeScene(int scene)
    {
        EnemyDefeated = 0;
        TotalEnemy = 0;
        SceneManager.LoadScene(scene);
    }

    /// <summary>
    /// Check if the record file exists, if it exists, read it
    /// </summary>
    public void CheckRecord()
    {
        if (!File.Exists("AllRecord.txt"))
        {
            StreamWriter Record = new StreamWriter("AllRecord.txt");
            for(int i = 0; i<allInfoLevels.Length;i++)
            {
                Record.WriteLine("*");
                Record.WriteLine(0);
            }
            Record.Close();
        }
        else
        {
            StreamReader Record = new StreamReader("AllRecord.txt");
            int cont = 0;
            while(!Record.EndOfStream)
            {
                allInfoLevels[cont].recordMan = Record.ReadLine();
                allInfoLevels[cont].record = int.Parse(Record.ReadLine());
                cont++;
            }
            Record.Close();
        }

    }

    /// <summary>
    /// Writes in record txt if current player make a new record time
    /// </summary>
    /// <param name="currRecord"></param>
    public void NewRecord(float currRecord)
    {
        allInfoLevels[currLevel].record = currRecord;
        allInfoLevels[currLevel].recordMan = playerName;
        StreamWriter record = new StreamWriter("AllRecord.txt");
        for(int i = 0;i<allInfoLevels.Length;i++)
        {
            record.WriteLine(allInfoLevels[i].recordMan);
            record.WriteLine(allInfoLevels[i].record);
        }
        record.Close();
    }

    /// <summary>
    /// create a new file for a new player if it does not exist, if it exists, read it
    /// </summary>
    /// <param name="name"></param>
    public void CurrentPlayer(string name)
    {
        playerName = name;

        if (!File.Exists(name+".txt"))
        {
            StreamWriter newPlayer = new StreamWriter(name + ".txt");
            newPlayer.WriteLine("C" + currLevel);
            for(int i = 0; i<allInfoLevels.Length;i++)
            {
                newPlayer.WriteLine("N" + i);
                newPlayer.WriteLine(allInfoLevels[i].time);
            }
            newPlayer.Close();
        }
        else
        {
            StreamReader newPlayer = new StreamReader(name + ".txt");
            while(!newPlayer.EndOfStream)
            {
                string cadena = newPlayer.ReadLine();
                switch(cadena[0])
                {
                    case 'N':
                        int index = int.Parse(cadena[1].ToString());
                        allInfoLevels[index].level = int.Parse(cadena[1].ToString());
                        cadena = newPlayer.ReadLine();
                        float num = float.Parse(cadena);
                        allInfoLevels[index].time = num;
                        break;
                    case 'C':
                        //LevelController lvl = GameObject.Find("Lvlpositions").GetComponent<LevelController>();
                        //lvl.FastActive((int)cadena[1]);
                        break;
                }
            }
            newPlayer.Close();

        }
        CheckRecord();

    }

    /// <summary>
    /// Write in txt current player info
    /// </summary>
    public void ReWritePlayerTime()
    {
        StreamWriter newPlayer = new StreamWriter(playerName + ".txt");
        newPlayer.WriteLine("C" + maxLevel);
        for (int i = 0; i<allInfoLevels.Length;i++)
        {
            newPlayer.WriteLine("N" +i);
            newPlayer.WriteLine(allInfoLevels[i].time);
        }
        newPlayer.Close();
    }

    /// <summary>
    /// Return best time in index level
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public int BestTime(int index)
    {
        return (int)allInfoLevels[index].time;
    }

    /// <summary>
    /// return best record time in index level
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public int BestRecord(int index)
    {
        return (int)allInfoLevels[index].record;
    }

    /// <summary>
    /// return the name of the best record in index level
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public string BestRecordMan(int index)
    {
        return allInfoLevels[index].recordMan;
    }

    public void NextLevel(int amount)
    {
        currLevel += amount;
    }
    /// <summary>
    /// Quit game
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();
    }

}
*/