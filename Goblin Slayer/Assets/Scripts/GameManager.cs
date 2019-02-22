using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public int vida;
    public int index;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
       
	}
    /// <summary>
  

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
   
}
