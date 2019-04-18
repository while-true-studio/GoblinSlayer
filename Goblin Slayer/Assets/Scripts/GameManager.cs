using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia = null;
    private int EnemyDefeated;
    private int TotalEnemy;

	// Use this for initialization
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

    public void AddTotalEnemy(int amount)
    {
        TotalEnemy += amount;
    }

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
    /// Reseteara la escena si  la vida del jugador es 0 o inferior 
    /// </summary>
    /// <param name="index">
    /// Indica qué escena se va a reiniciar
    /// </param
    public void ResetScene(int index)
    { 
        SceneManager.LoadScene(index);
    }
   

    public void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

}
