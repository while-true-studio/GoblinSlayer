using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia = null;
    public int vida;
    public int index;

	// Use this for initialization
	private void Awake ()
    {
		if(instancia == null)
        {
            instancia = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
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
   

    public void ChangeScene(int index)
    {
        SceneManager.LoadScene(index);
    }

}
