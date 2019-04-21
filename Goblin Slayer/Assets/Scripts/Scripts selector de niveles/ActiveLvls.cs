using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public class ActiveLvls : MonoBehaviour
{
    public GameObject[] activePaths;
    private Renderer currPath;
    public float timeToRender;
    private float timer;

	void Start ()
    {
		for (int i = 0; i<activePaths.Length;i++)
        {
            activePaths[i].SetActive(false);
            activePaths[i].GetComponent<Renderer>().material.SetColor("_Color",Color.clear);
        }
    }

    private void Update()
    {
        if (currPath!=null)
        {
            timer += Time.deltaTime * timeToRender;
            currPath.material.SetColor("_Color",Color.Lerp(Color.clear,Color.white,timer));
        }
        else
        {
            currPath = null;
            timeToRender = 0.0f;
        }
    }

    /// <summary>
    /// Activate sprite of a index level
    /// </summary>
    /// <param name="index"></param>
    public void ActiveSpriteLevel(int index)
    {
        activePaths[index].SetActive(true);
        currPath = activePaths[index].GetComponent<Renderer>();
    }

}
