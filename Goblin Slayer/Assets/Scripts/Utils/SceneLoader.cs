using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public Slider slider = null;
    private Canvas loadingCanvas;
    private void Start()
    {
        if (slider == null)
            slider = GetComponentInChildren<Slider>();
        loadingCanvas = GetComponentInChildren<Canvas>();
        loadingCanvas.gameObject.SetActive(false);
    }

    public void LoadScene(Scene scene)
    {
        loadingCanvas.gameObject.SetActive(true);
        StartCoroutine(_LoadScene((int) scene));
    }

    IEnumerator _LoadScene(int index)
    {

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);
        while (!asyncOperation.isDone)
        {
            float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
            slider.value = progress;
            yield return null;
        }
        loadingCanvas.gameObject.SetActive(false);
    }
}
