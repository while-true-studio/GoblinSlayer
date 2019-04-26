using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia = null;
    private int EnemyDefeated;
    private int TotalEnemy;
    public string playerName{ get; private set; }
    public int currLevel;
    public int totalLevel = 3;
    private playerInfo[] allInfoLevels;
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
        currLevel = 1;
        allInfoLevels = new playerInfo[totalLevel+1];
    }


    public void GameOver()
    {
        DamageScreen hud = GameObject.Find("HUD").GetComponent<DamageScreen>();
        if (hud) hud.StartAnimation();
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
        allInfoLevels[currLevel].time = Go.currentTime;
        ReWritePlayerTime();

        if (allInfoLevels[currLevel].record < Go.currentTime)
            NewRecord(Go.currentTime);
        StartCoroutine(ActiveNextLvl());
        ChangeScene(0);
    }

    /// <summary>
    /// Activete next level in level select
    /// </summary>
    /// <returns></returns>
    private IEnumerator ActiveNextLvl()
    {
        yield return new WaitForSecondsRealtime(3.0f);
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
            for(int i = 1; i<allInfoLevels.Length;i++)
            {
                Record.WriteLine("*");
                Record.WriteLine(0);
            }
            Record.Close();
        }
        else
        {
            StreamReader Record = new StreamReader("AllRecord.txt");
            int cont = 1;
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
        for(int i = 1;i<allInfoLevels.Length;i++)
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
            for(int i = 1; i<allInfoLevels.Length;i++)
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
                        //currLevel = int.Parse(cadena[1].ToString());
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
        newPlayer.WriteLine("C" + currLevel);
        for (int i = 1; i<allInfoLevels.Length;i++)
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

}
