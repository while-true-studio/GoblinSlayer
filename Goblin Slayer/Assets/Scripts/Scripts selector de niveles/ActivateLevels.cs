using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public class ActivateLevels : MonoBehaviour
{
    public Renderer[] activePaths;
    public float timeToRender;
    private float timer;
    public AudioClip newLevelSound;

    /// <summary>
    /// Activate sprite of a index level
    /// </summary>
    /// <param name="index"></param>
    public void ActiveSpriteLevel(int index)
    {
        Camera.main.GetComponent<SoundEffectsMenu>().PlayEffect(newLevelSound);
        StartCoroutine(ShowEffect(index));
    }

    public void FastActiveSprite(int index)
    {
        activePaths[index].gameObject.SetActive(true);
        activePaths[index].material.SetColor("_Color", Color.white);
    }


    IEnumerator ShowEffect(int index)
    {
        Debug.Log("Showing Effect: Start");
        activePaths[index].gameObject.SetActive(true);
        while (timer < timeToRender)
        {
            timer += Time.deltaTime * timeToRender;
            activePaths[index].material.SetColor("_Color", Color.Lerp(Color.clear, Color.white, timer));
            yield return null;
        }
        Debug.Log("Showing Effect: Stop");
    }
}
