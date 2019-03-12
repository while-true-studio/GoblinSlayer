using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class PauseBehaviour : MonoBehaviour
{

    //Script for positioning pause elements in the visual screen 
    //or in another position to not watch them.


    private void Start()
    {
        DesactiveButtom();
    }

    public void ActiveButtom()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);

    }

    public void DesactiveButtom()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
    }


}
