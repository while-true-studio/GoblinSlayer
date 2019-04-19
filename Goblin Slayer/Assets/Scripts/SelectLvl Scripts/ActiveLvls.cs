using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveLvls : MonoBehaviour
{
    public GameObject[] activePaths;

	void Start ()
    {
		for (int i = 0; i<activePaths.Length;i++)
        {
            activePaths[i].SetActive(false);
        }
    }
	
    public void ActiveSpriteLevel(int index)
    {
        activePaths[index].SetActive(true);
    }

}
