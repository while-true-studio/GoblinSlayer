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
    public AudioClip NewLevelSound;

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
        else { currPath = null; }

    }

    /// <summary>
    /// Activate sprite of a index level
    /// </summary>
    /// <param name="index"></param>
    public void ActiveSpriteLevel(int index)
    {
        Camera.main.GetComponent<SoundEffectsMenu>().PlayEffect(NewLevelSound);
        activePaths[index].SetActive(true);
        currPath = activePaths[index].GetComponent<Renderer>();   
    }

    public void FastActiveSprite(int index)
    {
        activePaths[index].SetActive(true);
        activePaths[index].GetComponent<Renderer>().material.SetColor("_Color", Color.white);
    }

}
